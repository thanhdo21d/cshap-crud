using System;
using System.Linq;
using cru.Db;
using cru.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cru.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)

        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return NotFound();
            
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                var p = _db.Products.Find(product.Id);
                if (p != null)
                {
                    _db.Entry<Product>(p).State = EntityState.Detached;
                    _db.Products.Update(product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Error"] = "San pham ko ton tai";
                }
            }
            return View(product);
        }

        public IActionResult Delete(int id) {
            var p = _db.Products.Find(id);
            if (p != null)
            {
                
                _db.Products.Remove(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound("San pham ko ton tai");
        }


        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }catch (Exception e)
            {
                ViewData["Error"] = e.Message;
            }

            return View(product);
        }
       
    }
}
