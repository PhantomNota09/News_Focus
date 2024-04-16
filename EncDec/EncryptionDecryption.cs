using System;

namespace EncDec
{
    public class EncryptionDecryption
    {
        // Function to encrypt the string
        public string Encrypt(string s)
        {
            try
            {
                // Convert the string to bytes using UTF-8 encoding
                byte[] encData_byte = System.Text.Encoding.UTF8.GetBytes(s);

                // Encode the byte array to a Base64 string
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                // If an error occurs during encryption, throw an exception
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        // Function to decrypt the string
        public string Decrypt(string s)
        {
            // Initialize UTF-8 encoder and decoder
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            // Convert the Base64 string to a byte array
            byte[] todecode_byte = Convert.FromBase64String(s);

            // Calculate the number of characters in the decoded byte array
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

            // Initialize a character array to store the decoded characters
            char[] decoded_char = new char[charCount];

            // Decode the byte array to characters
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

            // Create a string from the decoded characters
            string result = new String(decoded_char);
            return result;
        }
    }
}
