# ECS Deployment Notes (2026-06-09)

## Problem
Pushing to ECS always crashed with:
```
System.ArgumentNullException: Value cannot be null. (Parameter 'nameOrConnectionString')
at Hangfire.SqlServerStorageExtensions.UseSqlServerStorage
at YAHALLO.Startup.ConfigureServices (Startup.cs:line 46)
```

## Root Causes & Fixes

### 1. Hangfire connection string null
**Cause**: `DotEnv.Load()` in Startup.cs loads env vars from `.env` file. On ECS there's no `.env` file, so `Cloud_Server` env var was null.

**Fix**: Changed `DotEnv.Load()` to:
```csharp
DotEnv.Load(new DotEnvOptions(ignoreExceptions: true, overwriteExistingVars: false));
```
- `ignoreExceptions: true` — won't crash if `.env` file is missing
- `overwriteExistingVars: false` — won't overwrite env vars set by ECS

### 2. Environment variables not set in ECS
**Cause**: `.env` file is in `.dockerignore` (correct), but env vars weren't set in the ECS task definition.

**Fix**: Added all env vars to the ECS task definition via AWS Console:
- ECS -> Task Definitions -> yahallo-task -> Create new revision
- Added: `Encrypt_Context`, `Cloud_Server`, `Elastic_Url`, `Elastic_Key`, `Elastic_DefaultIndex`, `Authentication_SecretKey`, `Authentication_ValidAudience`, `Authentication_ValidIssuer`, `EmailConfiguration_SecretToken`, `EmailConfiguration_From`, `EmailConfiguration_Username`, `EmailConfiguration_Password`

### 3. Image pinned to SHA256 digest
**Cause**: Task definition used `yahallo@sha256:0609fb...` — an immutable reference. Pushing new images had no effect.

**Fix**: Changed image to `798294347635.dkr.ecr.ap-southeast-1.amazonaws.com/yahallo/yahallo:latest`

### 4. .NET 8 default port changed (MAIN ISSUE)
**Cause**: .NET 8 base images default to port **8080**, not 80. Container was running but listening on wrong port. ECS port mapping was set to 80.

**Fix**: Added to Dockerfile:
```dockerfile
ENV ASPNETCORE_URLS=http://+:80
```

Note: `launchSettings.json` only applies locally (dotnet run / Visual Studio). It is NOT included in the published Docker image.

### 5. Cloudflare SSL issue
**Cause**: Cloudflare proxy (orange cloud) tries HTTPS, but ALB only has HTTP listener.

**Fix**: In Cloudflare SSL/TLS settings, set encryption mode to **Flexible**.

---

## Infrastructure

| Component | Value |
|-----------|-------|
| Cluster | yahallo-ixvew1 |
| Service | yahallo-task-service-217d96md |
| Task Definition | yahallo-task (revision 3+) |
| ECR Repo | 798294347635.dkr.ecr.ap-southeast-1.amazonaws.com/yahallo/yahallo |
| Region | ap-southeast-1 |
| Fargate | 0.5 vCPU, 1 GiB |
| ALB | yahallo-alb-1437017339.ap-southeast-1.elb.amazonaws.com |
| Target Group | yahallo-tg (health check: /hc, port 80) |
| Security Group | sg-0f69af38c3c4ac2ff (port 80 open to 0.0.0.0/0) |
| Domain | api.yahallo.online (Cloudflare CNAME -> ALB, proxied) |

## Deploy Process (Manual)

1. Build Docker image
2. Tag and push to ECR with `:latest`
3. Go to ECS -> Clusters -> yahallo-ixvew1 -> service -> Update
4. Check "Force new deployment" -> Update
5. ECS pulls new `:latest` image and restarts

## Task Definition Notes

- `register-task-definition` requires clean JSON — remove read-only fields: `taskDefinitionArn`, `revision`, `status`, `requiresAttributes`, `compatibilities`, `registeredAt`, `registeredBy`
- Remove `"taskRoleArn": null` (API rejects null values)
- Old task definition revisions are free (just blueprints), no need to delete them
- Fargate assigns a new public IP on every task restart — use ALB for stable endpoint

## Useful Commands

```bash
# Check logs
aws logs tail /ecs/yahallo-task --since 10m --region ap-southeast-1

# Get running task
aws ecs list-tasks --cluster yahallo-ixvew1 --service-name yahallo-task-service-217d96md --region ap-southeast-1

# Check task status
aws ecs describe-tasks --cluster yahallo-ixvew1 --tasks <task-arn> --region ap-southeast-1 --query "tasks[0].{status:lastStatus,stoppedReason:stoppedReason}"

# Get task public IP
aws ecs describe-tasks --cluster yahallo-ixvew1 --tasks <task-arn> --region ap-southeast-1 --query "tasks[0].attachments[0].details[?name=='networkInterfaceId'].value" --output text
# then:
aws ec2 describe-network-interfaces --network-interface-ids <eni-id> --region ap-southeast-1 --query "NetworkInterfaces[0].Association.PublicIp"

# Check security group rules
aws ec2 describe-security-groups --group-ids sg-0f69af38c3c4ac2ff --region ap-southeast-1 --query "SecurityGroups[0].IpPermissions"

# Check task definition env vars
aws ecs describe-task-definition --task-definition yahallo-task:3 --region ap-southeast-1 --query "taskDefinition.containerDefinitions[0].environment"

# Check latest ECR images
aws ecr describe-images --repository-name yahallo/yahallo --region ap-southeast-1 --query "imageDetails | sort_by(@, &imagePushedAt) | [-3:].[imageTags,imagePushedAt]"
```

## TODO
- [ ] Set up GitHub Actions for auto-deploy on push
- [ ] Add HTTPS listener on ALB with ACM certificate (instead of relying on Cloudflare Flexible SSL)
