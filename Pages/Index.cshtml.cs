using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Cupcakes.Data;
using Cupcakes.Models;

namespace Cupcakes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Cupcake> cupcakes = new();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {   
            cupcakes = DbContext.GetAllCupcakes();
            }
    }
}
