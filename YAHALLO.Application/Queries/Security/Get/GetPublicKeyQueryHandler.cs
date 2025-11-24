using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories.Security;

namespace YAHALLO.Application.Queries.Security.Get
{
    public class GetPublicKeyQueryHandler : IRequestHandler<GetPublicKeyQuery, string>
    {
        private readonly IKeypairGenerate _keypairGenerate;
        public GetPublicKeyQueryHandler(IKeypairGenerate keypairGenerate)
        {
            _keypairGenerate = keypairGenerate;
        }
        public Task<string> Handle(GetPublicKeyQuery request, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<string>();
            tcs.SetResult(_keypairGenerate.PublicKey);
            return tcs.Task;
        }
    }
}
