using Microsoft.AspNetCore.Mvc;
using Dummy_Proj.Models;
using Dummy_Proj.Interfaces;

namespace InteriorDesignStaticSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> Enquiry(string Name, string Email, string Message)
        {
            string subject = $"New Enquiry from {Name}";
            string body = $@"
            <h2>New Enquiry Received</h2>
            <p><strong>Name:</strong> {Name}</p>
            <p><strong>Email:</strong> {Email}</p>
            <p><strong>Message:</strong> {Message}</p>";

            await _mailService.SendEmailAsync("nehamkadam2002@gmail.com", subject, body);

            TempData["Success"] = "Thank you for reaching out!";
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var projects = new List<Project>
            {
                new Project
                {
                    Title = "Modern Living Room",
                    Description = "Warm-toned living space with natural textures.",
                    ImageUrl = "/images/newlivingroom1.webp"
                },
                new Project
                {
                    Title = "Cozy Bedroom",
                    Description = "Earthy hues and soft lighting for restful vibes.",
                    ImageUrl = "/images/newbedroom1.webp"
                },
                new Project
                {
                    Title = "Creative Kitchen",
                    Description = "Earthy hues and soft lighting for restful vibes.",
                    ImageUrl = "/images/newkitchen1.webp"
                },
                new Project
                {
                    Title = "Fun Kitchen",
                    Description = "Earthy hues and soft lighting for restful vibes.",
                    ImageUrl = "/images/newkitchen2.webp"
                },
                new Project
                {
                    Title = "Your Place",
                    Description = "Earthy hues and soft lighting for restful vibes.",
                    ImageUrl = "/images/newpic1.webp"
                },
                new Project
                {
                    Title = "Unwind",
                    Description = "Earthy hues and soft lighting for restful vibes.",
                    ImageUrl = "/images/newpic2.webp"
                }
            };

            return View(projects);
        }



    }
}