using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Project.Security
{
    /// <summary>
    /// Representa los algoritmos criptograficos.
    /// </summary>
    public class Cryptography
    {
        /// <summary>
        /// Representa el algoritmo de encriptación de datos.
        /// </summary>
        /// <param name="strToEncrypt">Recibe la cadena a encriptar.</param>
        /// <param name="Key">Recibe la clave de encriptación.</param>
        /// <returns>Devuelve la cadena encriptada.</returns>
        public static String Encrypt(String strToEncrypt, String Key)
        {
            // Trata los posibles errores.
            try
            {
                // Almacena la clave convertida en bytes.
                Byte[] keyArray;
                // Representa la cadena en forma de arreglo a cifrar.
                Byte[] ArrayToCipher = UTF8Encoding.UTF8.GetBytes(strToEncrypt);
                // Algoritmo MD5.
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                // Transforma en bytes la clave.
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                // Limpia el objeto MD5.
                hashmd5.Clear();
                // Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                // Establece la llave.
                tdes.Key = keyArray;
                // Establece el tipo de cifrado.
                tdes.Mode = CipherMode.ECB;
                // Establece el tipo de relleno.
                tdes.Padding = PaddingMode.PKCS7;
                // Define las operaciones básicas de transformación criptografica.
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                // Captura el arreglo transformado en el bloque final.
                Byte[] ArrayResult = cTransform.TransformFinalBlock(ArrayToCipher, 0, ArrayToCipher.Length);
                // Limpia el objeto TripleDES.
                tdes.Clear();
                // Captura la cadena encriptada a devolver.
                strToEncrypt = Convert.ToBase64String(ArrayResult, 0, ArrayResult.Length);
                // Devuelve la cadena encriptada.
                return strToEncrypt;
            }
            catch (Exception ex)
            {
                // Devuelve un mensaje con la especificación del error.
                return ex.Message;
            }
        }
        /// <summary>
        /// Representa el algoritmo de desencriptación de datos.
        /// </summary>
        /// <param name="strToDecrypt">Recibe la cadena encriptada a desencriptar.</param>
        /// <param name="Key">Recibe la clave de desencriptación.</param>
        /// <returns>Devuelve la cadena desencriptada.</returns>
        public static String Decrypt(String strToDecrypt, String Key)
        {
            // Trata los posibles errores.
            try
            {
                // Almacena la clave convertida en bytes.
                Byte[] keyArray;
                // Representa la cadena en forma de arreglo a cifrar.
                Byte[] ArrayToCipher = Convert.FromBase64String(strToDecrypt);
                // Algoritmo MD5.
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                // Transforma en bytes la clave.
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                // Limpia el objeto MD5.
                hashmd5.Clear();
                // Algoritmo TripleDES.
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                // Establece la llave.
                tdes.Key = keyArray;
                // Establece el tipo de cifrado.
                tdes.Mode = CipherMode.ECB;
                // Establece el tipo de relleno.
                tdes.Padding = PaddingMode.PKCS7;
                // Define las operaciones básicas de transformación criptografica.
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                // Captura el arreglo transformado en el bloque final.
                Byte[] resultArray = cTransform.TransformFinalBlock(ArrayToCipher, 0, ArrayToCipher.Length);
                // Limpia el objeto TripleDES.
                tdes.Clear();
                // Captura la cadena encriptada a devolver.
                strToDecrypt = UTF8Encoding.UTF8.GetString(resultArray);
                // Devuelve la cadena desencriptada.
                return strToDecrypt;
            }
            catch (Exception ex)
            {
                // Devuelve el mensaje de error.
                return ex.Message;
            }
        }
    }
}