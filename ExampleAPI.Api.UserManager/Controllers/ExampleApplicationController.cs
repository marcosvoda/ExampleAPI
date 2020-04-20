using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleAPI.Api.UserManager.Interfaces;
using ExampleAPI.Api.UserManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Api.UserManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleApplicationController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IProvinciasService _provinciasService;

        public ExampleApplicationController(IUsersService usersService, IProvinciasService provinciasService)
        {
            this._usersService = usersService;
            this._provinciasService = provinciasService;
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ExampleApplication/Login
        public async Task<IActionResult> PostUserLoginAsync(LoginModel model)
        {
            var result = await _usersService.PostUserLoginAsync(model).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("GetProvinciaInfo")]
        //GET : /api/ExampleApplication/GetInfoProvincia
        public async Task<IActionResult> GetInfoProvinciaAsync(RequestModel nombreProvincia)
        {
            var result = await _provinciasService.GetInfoProvinciaAsync(nombreProvincia).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                return Ok(result.Provincia);
            }
            return NotFound();
        }
    }
}