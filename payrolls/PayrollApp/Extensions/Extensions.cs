
using Microsoft.EntityFrameworkCore;
using PayrollApp.Models.DAL;
using PayrollApp.Models.Employment;
using PayrollApp.Models.Head;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using PayrollApp.Areas.PayrollAdmin.ViewModels;

namespace PayrollApp.Extensions
{
    public static class Extensions
    {

        public static ImageExtensions _randomFile { get; set; }
        private static string filePath = string.Empty;

        public static string GetImageFormat(this IFormFile Image)
        {
            return Image.FileName.Substring(Image.FileName.IndexOf(".") + 1, 3);
        }

        public static string GetEnvironmentPath(this IHostingEnvironment hostingEnvironment)
        {
            return Path.Combine(hostingEnvironment.WebRootPath, "File", "Images");
        }

        public static string GetImagePathForDelete(this IHostingEnvironment hostingEnvironment)
        {
            return filePath;
        }

        public static async Task<bool> ImageSaverAsync(this IFormFile Image, IHostingEnvironment hostingEnvironment, Employee employee)
        {
            _randomFile = new ImageExtensions();

            if (Image.ContentType == "image/jpeg" || Image.ContentType == "image/png" || Image.ContentType == "image/jpg")
            {
                string fileFormat = Image.GetImageFormat();

                employee.Image = _randomFile.GetRandomName(fileFormat);

                string path = GetEnvironmentPath(hostingEnvironment);
                filePath = Path.Combine(path, employee.Image);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fs);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> ImageSaverAsync(this IFormFile Image, IHostingEnvironment hostingEnvironment, RegisterViewModel model)
        {
            _randomFile = new ImageExtensions();

            if (Image.ContentType == "image/jpeg" || Image.ContentType == "image/png" || Image.ContentType == "image/jpg")
            {
                string fileFormat = Image.GetImageFormat();

                model.Image = _randomFile.GetRandomName(fileFormat);

                string path = GetEnvironmentPath(hostingEnvironment);
                filePath = Path.Combine(path, model.Image);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fs);
                    return true;
                }
            }
            return false;
        }
        //public static async Task<bool> ImageSaverAsync(this IFormFile Image, IHostingEnvironment hostingEnvironment, EditUsersViewModel model)
        //{
        //    _randomFile = new ImageExtensions();

        //    if (Image.ContentType == "image/jpeg" || Image.ContentType == "image/png" || Image.ContentType == "image/jpg")
        //    {
        //        string fileFormat = Image.GetImageFormat();

        //        model.Image = _randomFile.GetRandomName(fileFormat);

        //        string path = GetEnvironmentPath(hostingEnvironment);
        //        filePath = Path.Combine(path, model.Image);

        //        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //        {
        //            await Image.CopyToAsync(fs);
        //            return true;
        //        }
        //    }
        //    return false;
        //}




    }
}
