using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MunitionStockAndSupply.Data.Contexts;
using MunitionStockAndSupply.Models;

namespace MunitionStockAndSupply.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryDbContext _inventoryContext;
        private readonly CartDbContext _cartContext;


        public HomeController(ILogger<HomeController> logger, InventoryDbContext inventorContext, CartDbContext cartContext)
        {
            _logger = logger;
            _inventoryContext = inventorContext;
            _cartContext = cartContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Inventory()
        {
            try
            {
                return View(await _inventoryContext.Inventory.ToListAsync());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Cart()
        {
            try
            {
                return View(await _cartContext.Cart.ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Checkout()
        {
            return View();
        }

        public async Task AddToCart(string itemName, string itemPrice, int sellerID)
        {
            try
            {
                Cart item = new Cart()
                {
                    ItemName = itemName,
                    ItemPrice = itemPrice,
                    SellerID = sellerID
                };

                await _cartContext.AddAsync(item);
                await _cartContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var itemToDelete = await GetItemById(id);

            _cartContext.Remove(itemToDelete);
            await _cartContext.SaveChangesAsync();

            return View("Cart", await _cartContext.Cart.ToListAsync());
        }

        public async Task<Cart> GetItemById(int id)
            => await _cartContext.Cart.FindAsync(id);

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
