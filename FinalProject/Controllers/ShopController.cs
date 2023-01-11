using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProductService _productService;
        private readonly LayoutService _layoutService;

        public ShopController(AppDbContext context, ProductService productService, LayoutService layoutService)
        {
            _context = context;
            _productService = productService;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> settingDatas = await _layoutService.GetDatasFromSetting();

            int take = int.Parse(settingDatas["ProductTake"]);
            ViewBag.count = await _context.Products.Where(m => !m.IsDeleted).CountAsync();


            IEnumerable<ProductCategory> categories = await _context.ProductCategory
                .Where(m => !m.IsDeleted)
                .ToListAsync();
            IEnumerable<Size> sizes = await _context.Sizes
                .Where(m => !m.IsDeleted)
                .ToListAsync();
            IEnumerable<Product> products = await _productService.GetAll(6);
            IEnumerable<Brand> brands = await _context.Brands
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            ShopVM model = new ShopVM
            {
                categories = categories,
                Sizes = sizes,
                Products = products,
                Brands = brands,
            };

            return View(model);
        }

        public async Task<IActionResult> LoadMore(int skip)
        {
            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductCategory)
                .Include(m => m.ProductImages)
                .Include(m => m.Product_Sizes)
                .Include(m => m.Brands)
                .Skip(skip)
                .Take(3)
                .ToListAsync();

            return PartialView("_ProductsPartial", products);
        }
    }
}
