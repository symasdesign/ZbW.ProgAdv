using System.Text;

namespace CryptoLib {
    public class CaesarCipher {
        public string Name { get; }
        public string Description { get; }
        public int KeyStrength { get; }
        public bool IsSymmetric { get; }

        private int shift;

        public CaesarCipher(int shift) {
            this.shift = shift;
            this.Name = "Caesar Cipher";
            this.Description = "Ein einfacher Verschlüsselungsalgorithmus, der jeden Buchstaben im Text um eine feste Anzahl von Positionen im Alphabet verschiebt.";
            this.KeyStrength = 1; // Für Caesar Cipher ist die Schlüsselstärke sehr gering
            this.IsSymmetric = true; 
        }

        public string Encrypt(string plainText) {
            return ShiftText(plainText, shift);
        }

        public string Decrypt(string cipherText) {
            return ShiftText(cipherText, 26 - (shift % 26));
        }

        private string ShiftText(string text, int shiftAmount) {
            StringBuilder result = new StringBuilder();

            foreach (var c in text) {
                if (char.IsLetter(c)) {
                    var baseChar = char.IsUpper(c) ? 'A' : 'a';
                    var shiftedChar = (char)(((c - baseChar + shiftAmount) % 26) + baseChar);
                    result.Append(shiftedChar);
                } else {
                    // Nicht-Buchstaben bleiben unverändert
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
