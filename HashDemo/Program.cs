using System.Security.Cryptography;

namespace HashDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = "howdy@carlpaton.co.za";
            var password = "qwerty";

            //normal hash
            //~ less secure
            var hash = new Hash().Generate(password);

            //salt 
            //~ the salt would then need to be persisted to the db, else how would you compare the hashed password when the user logs in? :)
            //~ this is pretty secure
            var rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[16];
            rng.GetBytes(salt);
            var hashSalted = HashWithSalt.Generate(password, salt);

            //salt 
            //~ generate salt from email
            //~ this is secure enough and wont need the additional database column
            var hashSalted2 = HashWithSalt.Generate(email, password);
        }
    }
}
