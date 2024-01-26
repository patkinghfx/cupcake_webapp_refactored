using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cupcakes.Models;
using Cupcakes.Data;
using System.ComponentModel;


namespace Cupcakes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IHostEnvironment _environment;

        [BindProperty]
        public Cupcake Cupcake { get; set; } = new();

        [BindProperty]
        [DisplayName("Upload Photo")]
        public IFormFile FileUpload { get; set; }

        public CreateModel(ILogger<CreateModel > logger, IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment; 
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string filename = FileUpload.FileName;

            Cupcake.ImageFilename = filename;

            string projectRootPath = _environment.ContentRootPath;
            string fileSavePath = Path.Combine(projectRootPath, "wwwroot\\uploads", filename);

            using (FileStream fileStream = new FileStream(fileSavePath, FileMode.Create))
            {
                FileUpload.CopyTo(fileStream);
            }

            DbContext.AddNewCupcake(Cupcake);
            return RedirectToPage("Index");
        }
    }
}
