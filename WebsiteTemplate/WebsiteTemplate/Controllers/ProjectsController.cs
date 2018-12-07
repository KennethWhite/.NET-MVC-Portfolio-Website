using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebsiteTemplate.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Projects()
        {
            return View();
        }

        public FileResult Download(string name)
        {      
          
            var fileName = $"{CleanInput(name)}.zip";
            var filepath = $"Downloads/{fileName}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            //return File(fileBytes, "application/x-msdownload", fileName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(fileName));
        }

        static string CleanInput(string strIn)
        {
            try
            {
                //matches any character that is not a word character, a period, an @ symbol, or a hyphen.
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters, 
            // we return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

    }
}