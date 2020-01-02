using ice_cream.Models;
using ice_cream.Repositories;
using ice_cream.Repositories.Sessions;
using Smooth.IoC.UnitOfWork.Interfaces;
using System.Web.Mvc;
using PagedList;

namespace ice_cream.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(IDbFactory dbFactory, CategoryRepository categoryRepository) : base(dbFactory)
        {
            this._categoryRepository = categoryRepository;

        }

        public ActionResult Index(string Search, int? page)

        {

            using (var session = _dbFactory.Create<IAppSession>())
            {
                ViewBag.count = _categoryRepository.Count(session);
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                if (Search != null)
                {
                    return View("Index", this._categoryRepository.Searching(Search).ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return View("Index", this._categoryRepository.GetAll(session).ToPagedList(pageNumber, pageSize));
                }
                

            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category newItem)
        {

            if (ModelState.IsValid)
            {
                using (var session = _dbFactory.Create<IAppSession>())
                {
                    using (var uow = session.UnitOfWork())
                    {
                        if (_categoryRepository.IsExist(newItem))
                        {
                            ModelState.AddModelError("Loitrungten", "Tên danh mục đã tồn tại");
                            return View();
                        }
                        else if (_categoryRepository.SaveOrUpdate(newItem, uow) > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            return View(newItem);
        }
        public ActionResult Get(int id)
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                return View("Details", this._categoryRepository.GetKey(id, session));
            }

        }
        public ActionResult Edit(int id)
        {
            using (var session = _dbFactory.Create<IAppSession>())

            {
                Category category = new Category();
                ViewBag.name = category.CategoryName;
                return View("Edit", this._categoryRepository.GetKey(id, session));
            }

        }
        [HttpPost]
        public ActionResult Edit(Category category, int id)
        {


            using (var session = _dbFactory.Create<IAppSession>())
            {

                if (ModelState.IsValid)
                {


                    using (var uow = session.UnitOfWork())
                    {
                        var exitedItem = _categoryRepository.GetByName(category.CategoryName);
                        if (exitedItem != null) {
                            if (exitedItem.CategoryId != category.CategoryId) {
                                ModelState.AddModelError("Loitrungten", "Tên danh mục đã tồn tại");
                                return View();
                            }
                        }

                        if (_categoryRepository.SaveOrUpdate(category, uow) > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                return View(category);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                Category existedItem = this._categoryRepository.GetKey(id, session);
                if (existedItem != null)
                {
                    if (_categoryRepository.Delete(existedItem, session))
                    {

                        return RedirectToAction("Index");
                    }
                    else
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);

                }

                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }


    }
}