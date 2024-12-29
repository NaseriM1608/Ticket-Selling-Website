using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUserService : IEntityService<User> 
    {
        User Authenticate(string number, string password);
        string HashPassword(User user);
    }
}
