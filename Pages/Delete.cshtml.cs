using Cupcakes.Models;
using Cupcakes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cupcakes.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Cupcake Cupcake { get; set; } = new();


        public void OnGet(int id)
        {
            Cupcake = DbContext.GetCupcakeById(id);
        }

        public IActionResult OnPost()
        {
            DbContext.DeleteCupcake(Cupcake.CupcakeId);
            return RedirectToPage("Index");
        }
    }
}
