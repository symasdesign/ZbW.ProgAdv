
namespace CryptoLib {
    public class RsaCipher {
        public string Name { get; }
        public string Description { get; }
        public int KeyStrength { get; private set; }
        public bool IsSymmetric { get; }

        private string publicKey = null!;
        private string privateKey = null!;

        public RsaCipher(int keySize) {
            Name = "RSA Cipher";
            Description = "Ein asymmetrischer Verschlüsselungsalgorithmus, der ein Schlüsselpaar für die Verschlüsselung und Entschlüsselung verwendet.";
            KeyStrength = keySize;
            IsSymmetric = false;
            GenerateKeyPair(keySize);
        }

        private void GenerateKeyPair(int keySize) {
            Console.WriteLine($"Generating RSA key pair with keySize={keySize}...");
            this.publicKey = "RSA Public Key";
            this.privateKey = "RSA Private Key";
        }

        public string Encrypt(string plainText) {
            Console.WriteLine("Encrypting message with RSA...");
            return new string(plainText.Reverse().ToArray());
        }

        public string Decrypt(string cipherText) {
            Console.WriteLine("Decrypting message with RSA...");
            return new string(cipherText.Reverse().ToArray());
        }
    }
}
