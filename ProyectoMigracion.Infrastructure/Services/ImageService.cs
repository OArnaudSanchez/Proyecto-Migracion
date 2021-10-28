using Microsoft.AspNetCore.Http;
using ProyectoMigracion.Core.Enums;
using ProyectoMigracion.Core.Exceptions;
using ProyectoMigracion.Core.Helpers;
using ProyectoMigracion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProyectoMigracion.Infrastructure.Services
{
    public class ImageService : IHelperImage
    {
        public async Task<string> Upload(List<IFormFile> file, string directory)
        {
            if (file.Count == 0 || file == null)
            {
                throw new ApiException("No se ha seleccionado ningun archivo", 400);
            }

            if (CheckImageFile(file))
            {
                return await WriteFile(file, directory);
            }

            throw new ApiException("La Foto no Tiene un Formato Valido", 400);
        }

        private bool CheckImageFile(List<IFormFile> file)
        {
            foreach (var image in file)
            {
                byte[] fileBytes;
                var memoryStream = new MemoryStream();
                image.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
                return ImageHelper.GetImageFormat(fileBytes) != ImageFormat.unkown;
            }

            return false;
        }

        public async Task<string> WriteFile(List<IFormFile> file, string directory)
        {
            string fileName = "";
            try
            {
                foreach (var image in file)
                {
                    var extension = "." + image.FileName.Split('.')[image.FileName.Split('.').Length - 1];
                    fileName = Guid.NewGuid().ToString() + extension;

                    var path = Path.Combine(directory, $"Archivos\\", fileName);

                    var bits = new FileStream(path, FileMode.Create);

                    await image.CopyToAsync(bits);
                    bits.Close();
                }

            }
            catch (ApiException)
            {
                throw new ApiException("Ha ocurrido un error al subir la foto", 500);
            }

            return fileName;
        }
        public void DeleteImage(string fileName, string directory)
        {
            var imagePath = Path.Combine(directory, $"Archivos\\", fileName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

    }
}
