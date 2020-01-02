using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ice_cream.Repositories;
using ice_cream.Repositories.Sessions;
using Smooth.IoC.UnitOfWork.Interfaces;
using ice_cream.Models;
using PagedList;

namespace ice_cream.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ProductRepository _productRepository;

        public ProductController(IDbFactory dbFactory, ProductRepository productRepository) : base(dbFactory)
        {
            this._productRepository = productRepository;

        }
        // GET: Product

        public ActionResult Index(string Search, Product product, string Discontinued, int? page , int SupplierID =0, int CategoryId = 0)
        {

            using (var session = _dbFactory.Create<IAppSession>())
            {
                ViewBag.search = Search;
                int pageSize = 10;
                int pageNumber = (page ?? 1);

                var categoryList = _productRepository.GetNameCategory().ToList();
                categoryList.Insert(0, new Category()
                {
                    CategoryId = 0,
                    CategoryName = "-- Tất cả --"
                });
                ViewBag.Cate = categoryList;
                SelectList cate = new SelectList(categoryList, "CategoryId", "CategoryName", product.CategoryId);
                
                ViewBag.CategoryId = cate;

                var suppliersList = _productRepository.GetNameSuppliers().ToList();

                ViewBag.supplier = suppliersList;
                suppliersList.Insert(0, new Suppliers()
                {
                    SupplierID = 0,
                    CompanyName = "-- Tất Cả --"
                });
                SelectList supplier = new SelectList(suppliersList, "SupplierID", "CompanyName", product.SupplierID);
                ViewBag.SupplierID = supplier;
               
                if (Search != null)
                {
                    Search = Search.Trim();
                    return View("Index", this._productRepository.SearchSp(Search, CategoryId, SupplierID).ToPagedList(pageNumber, pageSize));
                }
               


                return View("Index", this._productRepository.Getjoin().ToPagedList(pageNumber, pageSize));


            }

        }
        public ActionResult Create()
        {

            SelectList supplier = new SelectList(_productRepository.GetNameSuppliers(), "SupplierID", "CompanyName");
            ViewBag.SupplierID = supplier;
            SelectList cate = new SelectList(_productRepository.GetNameCategory(), "CategoryId", "CategoryName");
            ViewBag.CategoryId = cate;
            return View();


        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                if (ModelState.IsValid)
                {

                    using (var uow = session.UnitOfWork())
                    {
                        //if (_productRepository.IsExist(product))
                        //{
                        //    ModelState.AddModelError("Loitrungten", "Tên sản phẩm đã tồn tại");
                        //    return View();
                        //}
                        //else 
                        if (_productRepository.SaveOrUpdate(product, uow) > 0)
                        {
                            return RedirectToAction("Index");
                        }
                        //_productRepository.SaveOrUpdate(new Product { CategoryId = 2, ProductName = "12" },uow);
                        //return RedirectToAction("Index");

                    }


                }
                SelectList cate = new SelectList(_productRepository.GetNameCategory(), "CategoryId", "CategoryName", product.CategoryId);
                ViewBag.CategoryId = cate;
                SelectList supplier = new SelectList(_productRepository.GetNameSuppliers(), "SupplierID", "CompanyName", product.SupplierID);
                ViewBag.SupplierID = supplier;
                return View();
            }

        }
        public ActionResult Details(int id)
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                return View("Details", this._productRepository.GetByIdSp(id));
            }

        }
        public ActionResult Edit(int id)
        {
            using (var session = _dbFactory.Create<IAppSession>())

            {
                var editItem = this._productRepository.GetKey(id, session);

                if (editItem != null)
                {
                    SelectList supplier = new SelectList(_productRepository.GetNameSuppliers(), "SupplierID", "CompanyName", editItem.SupplierID);
                    ViewBag.SupplierID = supplier;
                    ViewBag.CategoryId = new SelectList(_productRepository.GetNameCategory(), "CategoryId", "CategoryName", editItem.CategoryId);
                    return View(editItem);
                }
                else
                    return HttpNotFound();

            }

        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                if (ModelState.IsValid)
                {

                    using (var uow = session.UnitOfWork())
                    {
                        if (product.ProductName == null)
                        {
                            ModelState.AddModelError("LoiRong", "Mục này không được để trống !");
                            return View();

                        }
                        else if (_productRepository.SaveOrUpdate(product, uow) > 0)
                        {
                            return RedirectToAction("Index");
                        }
                        //_productRepository.SaveOrUpdate(new Product { CategoryId = 2, ProductName = "12" },uow);
                        //return RedirectToAction("Index");

                    }


                }
                SelectList cate = new SelectList(_productRepository.GetNameCategory(), "CategoryId", "CategoryName", product.CategoryId);
                ViewBag.CategoryId = cate;
                SelectList supplier = new SelectList(_productRepository.GetNameSuppliers(), "SupplierID", "CompanyName", product.SupplierID);
                ViewBag.SupplierID = supplier;
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                Product existedItem = this._productRepository.GetKey(id, session);
                if (existedItem != null)
                {
                    if (_productRepository.Delete(existedItem, session))
                    {

                        return RedirectToAction("Index");
                    }


                }

                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}