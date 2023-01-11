using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        #region Readonly
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        #endregion

        #region Constructor
        public HomeController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> FirstTrendingProducts = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductCategory)
                .Include(m => m.ProductImages)
                .Take(4)
                .ToListAsync();

            IEnumerable<Product> SecondTrendingProducts = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductCategory)
                .Include(m => m.ProductImages)
                .Skip(4)
                .Take(4)
                .ToListAsync();

            IEnumerable<Product> LastProducts = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductCategory)
                .Include(m => m.ProductImages)
                .OrderByDescending(m=>m.Id)
                .Take(4)
                .ToListAsync();

            IEnumerable<Slider> sliders = await _context.Sliders
                .Where(m => !m.IsDeleted)
                .ToListAsync();
            IEnumerable<Banner> banners = await _context.Banners
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            IEnumerable<Brand> brands = await _context.Brands.Where(m => !m.IsDeleted).ToListAsync();

            IEnumerable<Product> offerProduct = await _context.Products
                .Where(m => !m.IsDeleted)
                .OrderByDescending(m=>m.Discount)
                .Take(1)
                .ToListAsync();

            HomeVM model = new HomeVM
            {
                FirstTrendingProducts = FirstTrendingProducts,
                SecondTrendingProducts = SecondTrendingProducts,
                sliders = sliders,
                Brands = brands,
                LastProducts = LastProducts,
                Banners = banners,
                OfferProduct = offerProduct
            };

            return View(model);
        }

    }
}
