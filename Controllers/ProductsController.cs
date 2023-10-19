using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }

        [Route("products/index/{filterId?}")]
        [Route("items/index/{filterId?}")]
        [Route("products")]
        [Route("items/{filtername?}")]
        public IActionResult Index(int filterId, string filtername)
        {
            List<Product> products = myProducts;
            if (filtername != null) {
                products = products.Where(item => item.Name ==  filtername).ToList();
            }
            if (filterId != 0)
            {
                products = products.Where(item => item.Id == filterId).ToList();
            }
            return View(products);
        }

        public IActionResult View(int id)
        {
            Product product = myProducts.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); 
            }

            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = myProducts.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); 
            }

            return View(product); 
        }
        [HttpPost]
        public IActionResult Edit(int id, Product editedProduct)
        {
            Product productToUpdate = myProducts.FirstOrDefault(p => p.Id == id);

            if (productToUpdate == null)
            {
                return NotFound(); 
            }

            productToUpdate.Name = editedProduct.Name;
            productToUpdate.Description = editedProduct.Description;

            return RedirectToAction("View", new { id = productToUpdate.Id });
        }

        [Route("products/create")]
        [Route("products/new")]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                int? newProductId = myProducts.Max(p => p.Id) + 1;

                product.Id = newProductId;

                myProducts.Add(product);

                return RedirectToAction("View", new { id = product.Id });
            }

            return View(product);
        }

        [Route("products/create")]
        [Route("products/new")]
        public IActionResult Create()
        {
            
            return View();
        }

        [Route("products/delete/{id:int}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product productToDelete = myProducts.FirstOrDefault(p => p.Id == id);

            if (productToDelete == null)
            {
                return NotFound();
            }

            return View(productToDelete);
        }

        [Route("products/delete/{id:int}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Product productToDelete = myProducts.FirstOrDefault(dp => dp.Id == id);

            if (productToDelete == null)
            {
                return NotFound();
            }

            myProducts.Remove(productToDelete);

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
