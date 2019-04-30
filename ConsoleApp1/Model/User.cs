using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class User
    {
        public String UserName { get; set; }
        public String Password { get; set; }

        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   UserName == user.UserName &&
                   Password == user.Password;
        }

        public override int GetHashCode()
        {
            var hashCode = -514035047;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
