using Authenticaticate_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticaticate_Microservice.Repository
{
     interface IUserRep
    {
        public IEnumerable<User> getUserList();
    }
}
