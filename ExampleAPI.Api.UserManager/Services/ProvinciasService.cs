using ExampleAPI.Api.UserManager.Interfaces;
using ExampleAPI.Api.UserManager.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExampleAPI.Api.UserManager.Services
{
    public class ProvinciasService : IProvinciasService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProvinciasService> _logger;

        public ProvinciasService(IHttpClientFactory httpClientFactory, ILogger<ProvinciasService> logger)
        {
            this._httpClientFactory = httpClientFactory;
            this._logger = logger;
        }

        public async Task<(bool IsSuccess, ProvinciaModel Provincia, string ErrorMessage)> GetInfoProvinciaAsync(RequestModel request)
        {
            try
            {
                _logger?.LogError("Get all results");
                var client = _httpClientFactory.CreateClient("ProvinciasService");
                var respone = await client.GetAsync("georef/api/provincias");
                if (respone.IsSuccessStatusCode)
                {
                    var content = await respone.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var provs = JsonSerializer.Deserialize<ProvinciasResponseModel>(content, options);
                    
                    _logger?.LogError($"Filter by the given value: {request.NombreProvincia}");
                    var result = provs.Provincias.FirstOrDefault(p => p.Nombre.Equals(request.NombreProvincia));

                    if (result != null)
                        return (true, result, null);
                    else
                        return (false, null, "Not found");
                }

                return (true, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
