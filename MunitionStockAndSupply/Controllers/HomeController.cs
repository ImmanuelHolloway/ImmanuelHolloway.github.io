﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        private readonly CheckoutDbContext _checkoutContext;

        public HomeController(ILogger<HomeController> logger, InventoryDbContext inventorContext, CartDbContext cartContext, CheckoutDbContext checkoutContext)
        {
            _logger = logger;
            _inventoryContext = inventorContext;
            _cartContext = cartContext;
            _checkoutContext = checkoutContext;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Cart()
        {
            try
            {
                return View(await _cartContext.Cart.Where(x => x.UserId == CurrentUser()).ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Checkout(Checkout checkout)
        {
            return View();
        }

        public async Task AddToCart(string itemName, string itemPrice, int sellerID)
        {
            try
            {
                Cart item = new Cart()
                {
                    UserId = CurrentUser(),
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
            try
            {
                var itemToDelete = await GetItemById(id);

                if (itemToDelete != null)
                {
                    _cartContext.Remove(itemToDelete);
                    await _cartContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Cart", await _cartContext.Cart.Where(x => x.UserId == CurrentUser()).ToListAsync());
        }

        public async Task<IActionResult> Payment(Checkout paymentInformation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _checkoutContext.AddAsync(paymentInformation);
                    await _checkoutContext.SaveChangesAsync();

                    var clearCart = await _cartContext.Cart.Where(x => x.UserId == CurrentUser()).ToListAsync();
                    foreach (var item in clearCart)
                    {
                        _cartContext.Remove(item);
                    }
                    await _cartContext.SaveChangesAsync();

                    return View("ThankYou");
                }
                else
                {
                    return View("Checkout");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CurrentUser() 
            => User.Identity.Name;

        public async Task<Cart> GetItemById(int id)
            => await _cartContext.Cart.FindAsync(id);
    }
}
