using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProductDetailController(AppDbContext context ,  UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product product = await _context.Products
                .Where(m => !m.IsDeleted && m.Id == id)
                .Include(m => m.ProductImages)
                .Include(m => m.ProductCategory)
                .Include(m => m.Brands)
                .Include(m => m.Product_Sizes)
                .Include(m=> m.Comments)
                .ThenInclude(m=> m.AppUser)
                .FirstOrDefaultAsync();
            
            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Where(m => m.ProductCategoryId == product.ProductCategoryId)
                .Take(4)
                .OrderByDescending(m => m.Id)
                .Include(m => m.ProductImages)
                .Include(m => m.Brands)
                .ToListAsync();
            IEnumerable<Comment> comments = await _context.Comments
                .Where(m => !m.IsDeleted && m.ProductId == id)
                .OrderByDescending(m=>m.Id)
                .Take(5)
                .ToListAsync();

            ViewBag.Page = product.ProductCategory.Name;

            if (product == null)
            {
                return NotFound();
            }

            List<Product_Size> product_Sizes = await _context.Product_Size.Where(m => m.ProductId == id).ToListAsync();
            List<Size> sizes = new List<Size>();
            foreach (var size in product_Sizes)
            {
                Size dbSize = await _context.Sizes.Where(m => m.Id == size.SizeId).FirstOrDefaultAsync();
                sizes.Add(dbSize);
            }

            ProductDetailVM productDetailVM = new ProductDetailVM
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Discount = product.Discount,
                Description = product.Description,
                CategoryName = product.ProductCategory.Name,
                ProductImages = product.ProductImages,
                FeaturedProducts = products,
                MainImage = product.ProductImages.FirstOrDefault(m => m.IsMain)?.Image,
                Sizes = sizes,
                Stock = product.StockCount,
                Brand = product.Brands.Name,
                DiscountPrice = product.Price - ((product.Price / 100) * product.Discount),
                Comments = new Comment(),
                dbComments = comments,
                
            };

            return View(productDetailVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comments)
        {
            Product product = await _context.Products
                .Where(m => !m.IsDeleted && m.Id == comments.ProductId)
                .FirstOrDefaultAsync();

            AppUser user = await _userManager.GetUserAsync(User);
            Product product1 = await _context.Products
                 .Include(m => m.ProductImages)
                 .FirstOrDefaultAsync(m => m.Id == comments.Id);


            comments.AppUser = user;
            comments.AppUserId = user.Id;
            comments.AddingTime = DateTime.Now;
            comments.Products = product;

            await _context.Comments.AddAsync(comments);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = product.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int id)
        {

            Comment comment = await _context.Comments.FirstOrDefaultAsync(n => n.Id == id);


            comment.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = comment.Id });
        }
    }
}
