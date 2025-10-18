using System.Text;

namespace CryptoLib {
    public class ViginereCipher {
        public string Name { get; }
        public string Description { get; }
        public int KeyStrength { get; }
        public bool IsSymmetric { get; }

        private string key;

        public ViginereCipher(string key) {
            this.key = key.ToUpper();
            this.Name = "Vigenère Cipher";
            this.Description = "Ein Verschlüsselungsalgorithmus, der eine Folge von Caesar-Ciphern basierend auf den Buchstaben eines Schlüssels verwendet.";
            this.KeyStrength = key.Length;
            this.IsSymmetric = true;
        }

        public string Encrypt(string plainText) {
            return ProcessText(plainText, true);
        }

        public string Decrypt(string cipherText) {
            return ProcessText(cipherText, false);
        }

        private string ProcessText(string text, bool encrypt) {
            var result = new StringBuilder();
            var keyIndex = 0;
            var keyLength = key.Length;

            foreach (var c in text) {
                if (char.IsLetter(c)) {
                    var baseChar = char.IsUpper(c) ? 'A' : 'a';
                    var keyChar = key[keyIndex % keyLength];
                    var shift = keyChar - 'A';
                    if (!encrypt) {
                        shift = 26 - shift;
                    }
                    var shiftedChar = (char)(((c - baseChar + shift) % 26) + baseChar);
                    result.Append(shiftedChar);
                    keyIndex++;
                } else {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
