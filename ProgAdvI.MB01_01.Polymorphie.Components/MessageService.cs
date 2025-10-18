using CryptoLib;

namespace CommunicationLib {
    public class MessageService {
        public void SendMessage(CaesarCipher cipher, string message) {
            Console.WriteLine(cipher.Encrypt(message));
        }

        public void SendMessage(ViginereCipher cipher, string message) {
            Console.WriteLine(cipher.Encrypt(message));
        }

        public void SendMessage(RsaCipher cipher, string message) {
            Console.WriteLine(cipher.Encrypt(message));
        }
    }
}
