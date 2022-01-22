using AspnetRunBasics.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public ProductModel(IProductRepository productRepository, ICartRepository cartRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        }

        public IEnumerable<Entities.Category> CategoryList { get; set; } = new List<Entities.Category>();
        public IEnumerable<Entities.Product> ProductList { get; set; } = new List<Entities.Product>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            CategoryList = await _productRepository.GetCategoriesAsync();

            if (categoryId.HasValue)
            {
                ProductList = await _productRepository.GetProductsByCategoryAsync(categoryId.Value);
                SelectedCategory = CategoryList.FirstOrDefault(c => c.Id == categoryId.Value)?.Name;
            }
            else
            {
                ProductList = await _productRepository.GetProductsAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _cartRepository.AddItemAsync("test", productId);
            return RedirectToPage("Cart");
        }
    }
}