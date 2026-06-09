FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["YAHALLO/YAHALLO.csproj", "YAHALLO/"]
COPY ["YAHALLO.Application/YAHALLO.Application.csproj", "YAHALLO.Application/"]
COPY ["YAHALLO.Domain/YAHALLO.Domain.csproj", "YAHALLO.Domain/"]
COPY ["YAHALLO.Infrastructure/YAHALLO.Infrastructure.csproj", "YAHALLO.Infrastructure/"]
RUN dotnet restore "YAHALLO/YAHALLO.csproj"
COPY . .
WORKDIR "/src/YAHALLO"
RUN dotnet build "YAHALLO.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "YAHALLO.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "YAHALLO.dll"]
