using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public IndexModel(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _catalogService.GetCatalogsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            // 1- Get product by Id
            var product = await _catalogService.GetCatalogAsync(productId);

            // 2- Get Bob Basket
            var userName = "Bob";
            var basket = await _basketService.GetBasketAsync(userName);

            // 3- Construct new Item
            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Color = "Black"
            });

            // 4- Update the basket
            var basketUpdated = await _basketService.UpdateBasketAsync(basket);

            // 5- Redirect to Cart page
            return RedirectToPage("Cart");
        }
    }
}
