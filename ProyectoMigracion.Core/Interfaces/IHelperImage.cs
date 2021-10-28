using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface IHelperImage
    {
        Task<string> Upload(List<IFormFile> imagen, string directorio);
        void DeleteImage(string nombre, string directorio);
    }
}
