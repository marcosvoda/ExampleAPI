using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Api.UserManager.Mappers
{
    public class UsersMapper : AutoMapper.Profile
    {
        public UsersMapper()
        {
            CreateMap<Db.ApplicationUser, Models.UserModel>();
        }
    }
}
