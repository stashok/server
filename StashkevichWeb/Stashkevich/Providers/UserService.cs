using Stashkevich.Models;
using System.Collections.Generic;
using System.Linq;

namespace Stashkevich.Providers
{

    public class Stat
    {
        public int recv { get; set; }
        public int send { get; set; }
    }

    public class UserService
    {
        stashkevichEntities db = new stashkevichEntities();

        public User Validate(string userName, string password)
       => db.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);

        public List<User> GetUserList()
        {
            return db.Users.OrderBy(x => x.UserName).ToList();
        }
    }
}