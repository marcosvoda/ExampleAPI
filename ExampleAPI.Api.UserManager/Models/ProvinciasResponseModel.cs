using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Api.UserManager.Models
{
    public class ProvinciasResponseModel
    {
        public int Cantidad { get; set; }
        public int Inicio { get; set; }
        public List<ProvinciaModel> Provincias { get; set; }
    }

    public class ProvinciaModel
    {
        public CentroideModel Centroide { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }

    }

    public class CentroideModel
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
