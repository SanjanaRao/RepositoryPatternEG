using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EGRepositoryPattern.Models;
using EGRepositoryPattern.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EGRepositoryPattern.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWorkInterface _unitOfWork;

        public ProductController(IUnitOfWorkInterface unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Add(product);
                _unitOfWork.SaveChanges();
               
                return RedirectToAction("Index", "Product");
            }
            
            return View();
        }
        public IActionResult Edit(int Id)
        {
            if ( Id == 0)
            {
                return NotFound();
            }
            Product obj = _unitOfWork.ProductRepository.GetById(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            _unitOfWork.ProductRepository.Update(obj);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            Product obj = _unitOfWork.ProductRepository.GetById(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Product obj = _unitOfWork.ProductRepository.GetById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Delete(obj);
            _unitOfWork.SaveChanges();
           
            return RedirectToAction("Index");
        }
    }
}

