using CommunicationLib;
using CryptoLib;
using System.Security.Cryptography;

namespace Application {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Willkommen zum Verschlüsselungsprogramm!");
            Console.WriteLine("Bitte wählen Sie einen Verschlüsselungsalgorithmus aus:");
            Console.WriteLine("1. Caesar Cipher");
            Console.WriteLine("2. Vigenère Cipher");
            Console.WriteLine("3. RSA Cipher");
            Console.Write("Ihre Auswahl (1/2/3): ");

            var selection = Console.ReadLine();
            Console.WriteLine();

            var messageService = new MessageService();
            string message = string.Empty;

            switch (selection) {
                case "1":
                    Console.WriteLine("Sie haben Caesar Cipher ausgewählt.");
                    Console.Write("Bitte geben Sie die Verschiebung (Shift) ein (z.B. 3): ");
                    var shiftInput = Console.ReadLine();
                    if (int.TryParse(shiftInput, out int shift)) {
                        var caesar = new CaesarCipher(shift);
                        Console.Write("Bitte geben Sie die Nachricht ein, die verschlüsselt werden soll: ");
                        message = Console.ReadLine();
                        if (string.IsNullOrEmpty(message)) {
                            break;
                        }
                        messageService.SendMessage(caesar, message);
                    } else {
                        Console.WriteLine("Ungültige Eingabe für die Verschiebung. Programm wird beendet.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Sie haben Vigenère Cipher ausgewählt.");
                    Console.Write("Bitte geben Sie den Schlüssel ein (nur Buchstaben): ");
                    var key = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(key) && IsAllLetters(key)) {
                        var vigenere = new ViginereCipher(key);
                        Console.Write($"Bitte geben Sie die Nachricht ein, die verschlüsselt werden soll (KeyStrength={vigenere.KeyStrength}): ");
                        message = Console.ReadLine();
                        if (string.IsNullOrEmpty(message)) {
                            break;
                        }
                        messageService.SendMessage(vigenere, message);
                    } else {
                        Console.WriteLine("Ungültiger Schlüssel. Der Schlüssel muss nur aus Buchstaben bestehen. Programm wird beendet.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Sie haben RSA Cipher ausgewählt.");
                    Console.Write("Bitte geben Sie die gewünschte Schlüssellänge in Bits ein (z.B. 512): ");
                    var keySizeInput = Console.ReadLine();
                    if (int.TryParse(keySizeInput, out int keySize)) {
                        var rsa = new RsaCipher(keySize);

                        Console.Write($"Bitte geben Sie die Nachricht ein, die verschlüsselt werden soll (KeyStrength={rsa.KeyStrength}): ");
                        message = Console.ReadLine();
                        if (string.IsNullOrEmpty(message)) {
                            break;
                        }
                        messageService.SendMessage(rsa, message);
                    } else {
                        Console.WriteLine("Ungültige Schlüssellänge. ");
                    }

                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Programm wird beendet.");
                    break;
            }

            Console.WriteLine("\nVerschlüsselung abgeschlossen. Drücken Sie eine beliebige Taste zum Beenden.");
            Console.ReadKey();
        }

        private static bool IsAllLetters(string input) {
            foreach (var c in input) {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}