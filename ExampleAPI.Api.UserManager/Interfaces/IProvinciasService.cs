using ExampleAPI.Api.UserManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Api.UserManager.Interfaces
{
    public interface IProvinciasService
    {
        Task<(bool IsSuccess, ProvinciaModel Provincia, string ErrorMessage)> GetInfoProvinciaAsync(RequestModel nombre);
    }
}
