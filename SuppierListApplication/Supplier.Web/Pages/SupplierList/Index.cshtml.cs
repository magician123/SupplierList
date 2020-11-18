using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Supplier.Web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.Web.Pages.SupplierList
{
    public class IndexModel : PageModel
    {
        private readonly SupplierDbContext _supplierDbContext;

        public IndexModel(SupplierDbContext supplierDbContext)
        {
            _supplierDbContext = supplierDbContext;
        }

        public IEnumerable<Model.Supplier> Suppliers { get; set; }


        public async Task OnGet()
        {
            Suppliers = await _supplierDbContext.Suppliers.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var supplier = await _supplierDbContext.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _supplierDbContext.Suppliers.Remove(supplier);
            await _supplierDbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
