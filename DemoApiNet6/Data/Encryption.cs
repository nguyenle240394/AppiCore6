using System.Security.Cryptography;
using System.Text;

namespace DemoApiNet6.Data
{
    public class Encryption
    {
        public Encryption()
        {
        }
        public byte[] Keys { get; } = new byte[] { 142, 187, 154, 220, 54, 145, 138, 139, 245, 236, 245, 112, 223, 189, 98, 87 };
        public byte[] IVs { get; } = new byte[] { 124, 245, 25, 89, 23, 179, 198, 199, 200, 56, 45, 23, 17, 19, 59, 26 };
        public string Encrypt(string sValues, byte[] bKey, byte[] bIV)
        {
            string _pas = null;
            try
            {
                ASCIIEncoding textConverter = new ASCIIEncoding();
                RijndaelManaged myRijndael = new RijndaelManaged();
                byte[] encrypted;
                byte[] toEncrypt;
                string original = sValues;
                // Get an encryptor.
                ICryptoTransform encryptor = myRijndael.CreateEncryptor(bKey, bIV);
                // Encrypt the data.
                MemoryStream msEncrypt = new MemoryStream();
                CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                // Convert the data to a byte array.
                toEncrypt = textConverter.GetBytes(original);
                // Write all data to the crypto stream and flush it.
                csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                csEncrypt.FlushFinalBlock();
                // Get encrypted array of bytes.
                encrypted = msEncrypt.ToArray();
                msEncrypt.Close();
                _pas = Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                _pas = null;
            }
            return _pas;
        }
        public string Encrypt(string sValues)
        {
            return this.Encrypt(sValues, this.Keys, this.IVs);
        }
        public string Decrypt(string sValues, byte[] bKey, byte[] bIV)
        {
            if (string.IsNullOrWhiteSpace(sValues))
                return "";
            string _pas = null;
            try
            {
                ASCIIEncoding textConverter = new ASCIIEncoding();
                byte[] encrypted = Convert.FromBase64CharArray(sValues.ToCharArray(), 0, sValues.Length);
                Convert.FromBase64CharArray(sValues.ToCharArray(), 0, sValues.Length);
                RijndaelManaged myRijndael = new RijndaelManaged();
                ICryptoTransform decryptor = myRijndael.CreateDecryptor(bKey, bIV);
                // Now decrypt the previously encrypted message using the decryptor
                // obtained in the above step.
                MemoryStream msDecrypt = new MemoryStream(encrypted);
                CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                byte[] fromEncrypt;
                fromEncrypt = new byte[encrypted.Length + 1];
                // Read the data out of the crypto stream.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                // Convert the byte array back into a string.
                _pas = textConverter.GetString(fromEncrypt).Trim(new char[] { default(Char) });
                msDecrypt.Close();
                csDecrypt.Close();
            }
            catch (Exception ex)
            {
                _pas = null;
            }
            return _pas;
        }
        public string Decrypt(string sValues)
        {
            return this.Decrypt(sValues, this.Keys, this.IVs);
        }
    }
}