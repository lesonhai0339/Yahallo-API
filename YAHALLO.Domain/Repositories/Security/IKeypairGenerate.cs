using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories.Security
{
    public interface IKeypairGenerate
    {
        string PublicKey { get; }
        string Private { get; } 

        string Encrypt(string data);

        string Decrypt(string encryptedData);
    }
}
