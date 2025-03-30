using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OrderCLI.entity
{
    public class User
    {
        public static List<User> Users = new List<User>();
        public int Id { get; }
        public string Name { get; set; }
        public bool IsAdmin { get; }

        public User(int id, string name, bool isAdmin) {
            this.Id = id;
            this.Name = name;
            this.IsAdmin = isAdmin;
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Id == user.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
