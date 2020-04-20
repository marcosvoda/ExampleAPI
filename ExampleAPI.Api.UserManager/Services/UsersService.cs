using AutoMapper;
using ExampleAPI.Api.UserManager.Db;
using ExampleAPI.Api.UserManager.Interfaces;
using ExampleAPI.Api.UserManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Api.UserManager.Services
{
    public class UsersService : IUsersService
    {
        private readonly AuthenticationContext _dbContext;
        private readonly ILogger<UsersService> _logger;
        private readonly IMapper _mapper;

        public UsersService(AuthenticationContext dbContext, ILogger<UsersService> logger, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._logger = logger;
            this._mapper = mapper;

            SeedData();
        }

        private async void SeedData()
        {
            if (!_dbContext.ApplicationUsers.Any())
            {
                _dbContext.ApplicationUsers.Add(new Db.ApplicationUser() { Id = 1, FullName = "Marcos Vodanovich", UserName = "marcosvoda", Email = "marcosvoda@gmail.com", Password = "MarcosAccionaIT" });

                _dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, UserModel User, string ErrorMessage)> PostUserLoginAsync(LoginModel login)
        {
            try
            {
                _logger?.LogInformation("Querying customers");
                var user = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(c => c.UserName == login.UserName).ConfigureAwait(false);

                if (user != null && login.Password == user.Password)
                {
                    _logger?.LogInformation("Customer found");
                    var result = _mapper.Map<Db.ApplicationUser, Models.UserModel>(user);

                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
