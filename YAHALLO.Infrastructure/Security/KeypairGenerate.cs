using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Tls;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories.Security;

namespace YAHALLO.Infrastructure.Security
{
    public class KeypairGenerate : IKeypairGenerate
    {
        private readonly string _publicKey;
        private readonly string _privateKey;
        public KeypairGenerate(string context)
        {
            (string privateKey, string publicKey) = GenerateKeypair(context);
            _privateKey = privateKey;
            _publicKey = publicKey;
        }
        public string PublicKey => _publicKey;
        public string Private  => _privateKey;

        public string Encrypt(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            var publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(_publicKey));

            var engine = new Org.BouncyCastle.Crypto.Engines.RsaEngine();
            engine.Init(true, publicKeyParam);


            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] encryptedBytes = engine.ProcessBlock(dataBytes, 0, dataBytes.Length);

            return Convert.ToBase64String(encryptedBytes);
        }
        public string Decrypt(string encryptedData)
        {
            if (string.IsNullOrEmpty(encryptedData))
                throw new ArgumentNullException(nameof(encryptedData));

            var privateKeyParam = (RsaKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(_privateKey));

            var engine = new Org.BouncyCastle.Crypto.Engines.RsaEngine();
            engine.Init(false, privateKeyParam);


            byte[] encryptBytes = Convert.FromBase64String(encryptedData);
            byte[] decryptedBytes = engine.ProcessBlock(encryptBytes, 0, encryptBytes.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
        private (string, string) GenerateKeypair(string context)
        {
            var keyPair = RSAGenerate(context, 2048);

            var privateKey = ExportPrivateKey(keyPair.Private);
            var publicKey = ExportPublicKey(keyPair.Public);

            return (privateKey, publicKey);
        }
        private AsymmetricCipherKeyPair RSAGenerate(string seed, int keySize)
        {
            var seedBytes = Encoding.UTF8.GetBytes(seed);

            IRandomGenerator drg = new DigestRandomGenerator(new Sha256Digest());
            drg.AddSeedMaterial(seedBytes);

            var secureRandom = new SecureRandom(drg);
            secureRandom.SetSeed(seedBytes);    

            var keyGen = new RsaKeyPairGenerator();
            keyGen.Init(new KeyGenerationParameters(secureRandom, keySize));

            return keyGen.GenerateKeyPair();
        }
        private string ExportPrivateKey(AsymmetricKeyParameter privateKey)
        {
            return Convert.ToBase64String(PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey).GetEncoded());
        }
        private string ExportPublicKey(AsymmetricKeyParameter publicKey)
        {
            return Convert.ToBase64String(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey).GetEncoded());
        }
    }
}
