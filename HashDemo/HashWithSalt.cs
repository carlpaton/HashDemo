using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HashDemo
{
    //https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp
    //https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae

    public class HashWithSalt
    {
        public static string Generate(string password, byte[] salt)
        {
            var _value = Encoding.UTF8.GetBytes(password);
            var saltedValue = _value.Concat(salt).ToArray();

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(saltedValue);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               //.ToLower();
               ;

            return encoded;
        }

        public static string Generate(string password, string username)
        {
            var salt = Encoding.ASCII.GetBytes(username);
            var hashSalted = Generate(password, salt);
            return hashSalted;
        }
    }
}
