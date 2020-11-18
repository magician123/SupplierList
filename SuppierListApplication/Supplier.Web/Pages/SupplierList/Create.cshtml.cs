using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Supplier.Web.Model;
using System.Threading.Tasks;

namespace Supplier.Web.Pages.SupplierList
{
    public class CreateModel : PageModel
    {
        private readonly SupplierDbContext _supplierDbContext;

        public CreateModel(SupplierDbContext supplierDbContext)
        {
            _supplierDbContext = supplierDbContext;
        }
        [BindProperty]
        public Model.Supplier Supplier { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _supplierDbContext.Suppliers.AddAsync(Supplier);
                await _supplierDbContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
