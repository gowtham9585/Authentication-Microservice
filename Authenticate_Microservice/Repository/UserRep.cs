using Authenticaticate_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticaticate_Microservice.Repository
{
    public class UserRep : IUserRep
    {
        public IEnumerable<User> getUserList()
        {
            var userList = new List<User>
            {
                new User{UserId=1,Password="1234",Role="Customer"},
                new User{UserId=2,Password="12345",Role="Customer"},
                new User{UserId=1111,Password="123456",Role="Employee"}
            };
            return userList;
        }
    }
}
