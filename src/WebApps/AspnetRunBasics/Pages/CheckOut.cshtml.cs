using AspnetRunBasics.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;

        public CheckOutModel(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        [BindProperty]
        public Entities.Order Order { get; set; }

        public Entities.Cart Cart { get; set; } = new Entities.Cart();

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _cartRepository.GetCartByUserNameAsync("test");
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            Cart = await _cartRepository.GetCartByUserNameAsync("test");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = "test";
            Order.TotalPrice = Cart.TotalPrice;

            await _orderRepository.CheckOutAsync(Order);
            await _cartRepository.ClearCartAsync("test");
            
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}