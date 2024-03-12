using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using LR7_ASP_Zhyhlova.Models;


namespace LR7_ASP_Zhyhlova.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile([FromForm] FormInformation formInformation)
        {
            var text = JsonSerializer.Serialize(new
            {
                formInformation.FirstName,
                formInformation.Surname
            }, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            return File(stream, "application/txt", $"{formInformation.FileName}.txt");
        }
    }
}
