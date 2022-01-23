using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
    public class ProductDetailModel : PageModel
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public ProductDetailModel(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public CatalogModel Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _catalogService.GetCatalogAsync(productId);
            if (Product == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            // 1- Get product
            var product = await _catalogService.GetCatalogAsync(productId);

            // 2- Get Bob besket
            var userName = "Bob";
            var basket = await _basketService.GetBasketAsync(userName);

            // 3- Add new Item to besket
            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = Quantity,
                Color = Color
            });

            // 4- Update besked
            var basketUpdated = await _basketService.UpdateBasketAsync(basket);

            // 5- Redirect to Cart Page
            return RedirectToPage("Cart");
        }
    }
}