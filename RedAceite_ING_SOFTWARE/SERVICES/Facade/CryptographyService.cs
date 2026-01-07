using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio que proporciona funcionalidades de encriptación, desencriptación y hash de datos.
    /// Incluye algoritmos como MD5 y AES simétrico.
    /// </summary>
    public static class CryptographyService
    {
        /// <summary>
        /// Genera un hash MD5 a partir de un texto plano.
        /// </summary>
        /// <param name="textPlain">Texto de entrada a hashear.</param>
        /// <returns>Cadena con el hash MD5 en formato hexadecimal.</returns>
        public static string HashMd5(string textPlain)
        {
            StringBuilder sb = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(textPlain));
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }

        private static string encryptionKey = "cdinv-2024";

        /// <summary>
        /// Encripta un texto plano utilizando el algoritmo AES.
        /// </summary>
        /// <param name="clearText">Texto plano que se desea encriptar.</param>
        /// <returns>Texto encriptado en formato Base64.</returns>
        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
                {
                    0x49, 0x76, 0x61, 0x6e,
                    0x20, 0x4d, 0x65, 0x64,
                    0x76, 0x65, 0x64, 0x65,
                    0x76
                });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

            /// <summary>
            /// Desencripta un texto cifrado en formato Base64 usando el algoritmo AES.
            /// </summary>
            /// <param name="cipherText">Texto cifrado que se desea desencriptar.</param>
            /// <returns>Texto plano original.</returns>
        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
                {
                    0x49, 0x76, 0x61, 0x6e,
                    0x20, 0x4d, 0x65, 0x64,
                    0x76, 0x65, 0x64, 0x65,
                    0x76
                });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
