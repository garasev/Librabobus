using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Qoollo.Hamster.Backend
{
    public static class AuthOptions
    {
        /// <summary>Издатель токена</summary>
        public const string ISSUER = "LibrabobusServer"; 
        /// <summary>Потребитель токена</summary>
        public const string AUDIENCE = "LibrabobusClient"; 
        /// <summary>Ключ для шифрования</summary>
        const string KEY = "Librabobus secret key for authentication";   
        /// <summary>Время жизни токена - сутки</summary>
        public const int LIFETIME = 1440; 
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}