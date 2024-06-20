using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    public class Log
    {
        private List<User> Users;

        public Log()
        {
            Users = new List<User>();
        }

        public void Register(string username, string password, UserType userType)
        {
            if (Users.Exists(u => u.Username == username))
            {
                Console.WriteLine("Username already exists.");
                return;
            }
            Users.Add(new User(username, password, userType));
            Console.WriteLine("User registered successfully.");
        }

        public User Login(string username, string password)
        {
            User user = Users.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Login successful.");
                return user;
            }
            Console.WriteLine("Invalid username or password.");
            return null;
        }
    }

}
