using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SterlingePOSMerchant.Settings
{
    public class Encryption
    {
        public Encryption()
        {
        }

        public static string EncryptAES(string data, string key, string iv)
        {

            Console.WriteLine("AES Encryption and Decryption");


            Console.WriteLine("");
            Console.WriteLine("Initialization Vector, IV");

            byte[] Aes_iv = Encoding.UTF8.GetBytes(iv);
            // byte[] ivBytes = ASCIIEncoding.ASCII.GetBytes(keyText.PadLeft(16));


            //Aes_iv = asciiEncoding.GetBytes(iv);
            var vector = Convert.ToBase64String(Aes_iv);
            Console.WriteLine("Secret Key");
            // var Aes_secret = Security.GetKeyByte(32);//represents 256 bits which is the highest for AES

            //Aes_secret = Encoding.UTF8.GetBytes(key);
            //Aes_secret = asciiEncoding.GetBytes(key);

            byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadLeft(16));
            byte[] Aes_secret = keyBytes;
            var aes = Convert.ToBase64String(Aes_secret);
            Console.WriteLine("");
            Console.WriteLine("Encryption");

            var Aes_encryptedMsg = AesEncrypt(Encoding.UTF8.GetBytes(data), Aes_secret, Aes_iv);
            Console.WriteLine(Convert.ToBase64String(Aes_encryptedMsg));
            var encryptedData = ByteArrayToString(Aes_encryptedMsg);
            Console.WriteLine(" new bytes to hex conv is " + encryptedData);


            return encryptedData;
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private static byte[] AesEncrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new AesCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                //des.KeySize = 256;
                // des.BlockSize = 128;
                des.Key = key;
                des.IV = iv;

                using (var memorystream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memorystream, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memorystream.ToArray();
                }
            }
        }

    }
}
