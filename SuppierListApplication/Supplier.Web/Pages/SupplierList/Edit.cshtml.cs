using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Supplier.Web.Model;
using System.Threading.Tasks;

namespace Supplier.Web.Pages.SupplierList
{
    public class EditModel : PageModel
    {
        private readonly SupplierDbContext _supplierDbContext;

        public EditModel(SupplierDbContext supplierDbContext)
        {
            _supplierDbContext = supplierDbContext;
        }

        [BindProperty]

        public Model.Supplier Supplier { get; set; }
        public async Task OnGet(int id)
        {

            Supplier = await _supplierDbContext.Suppliers.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var currentSupplier = await _supplierDbContext.Suppliers.FindAsync(Supplier.Id);

                currentSupplier.Name = Supplier.Name;
                currentSupplier.City = Supplier.City;
                currentSupplier.PhoneNumber = Supplier.PhoneNumber;
                currentSupplier.Email = Supplier.Email;

                await _supplierDbContext.SaveChangesAsync();

                return RedirectToPage("Index");

            }

            return RedirectToPage();
            
        }
    }
}
