using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;
using System.Diagnostics;

namespace ShopingCartMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly QuickKartContext _context;
        QuickKartRepository repObj;
        private readonly IMapper _mapper;

        public ProductController(QuickKartContext context, IMapper mapper)
        {
            _context = context;
            repObj = new QuickKartRepository(_context);
            _mapper = mapper;
        }

        public IActionResult ViewProducts()
        {
            var lstEntityProducts = repObj.GetProducts();
            List<Models.Products> lstModelProducts = new List<Models.Products>();
            foreach (var product in lstEntityProducts)
            {
                lstModelProducts.Add(_mapper.Map<Models.Products>(product));
            }
            return View(lstModelProducts);
        }

        public IActionResult AddProduct()
        {
            string productId = repObj.GetNextProductId();
            ViewBag.nextProductId = productId;
            return View();
        }

        public IActionResult SaveAddedProduct(Models.Products product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = repObj.AddProduct(_mapper.Map<Products>(product));
                    if (status)
                    {
                        return RedirectToAction("ViewProducts");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }

            return View("AddProduct", product);
            
        }

        public IActionResult UpdateProduct(Models.Products product)
        {
            TempData["OldPrice"] = product.Price.ToString();
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveUpdatedProduct(Models.Products product)
        {
            bool status = false;
            ViewData["NewPrice"] = product.Price.ToString();
            if (ModelState.IsValid)
            {
                status = repObj.UpdateProduct(_mapper.Map<Products>(product));
                if (status)
                {
                    return View("Success");
                }
                else
                {
                    return View("Error");
                }
            }
            return View("UpdateProduct");
        }

        public IActionResult DeleteProduct(Models.Products product)
        {
            return View(product);
        }
        [HttpPost]
        public IActionResult SaveDeletion(string productId)
        {
            bool status = false;
            status = repObj.DeleteProduct(productId);
            try
            {
                if (status)
                {
                    return RedirectToAction("ViewProducts");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

    }
}
