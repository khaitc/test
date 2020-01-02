using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper.FastCrud;
using ice_cream.Repositories;
using ice_cream.Repositories.Sessions;
using ice_cream.Models;
using Smooth.IoC.UnitOfWork.Interfaces;

namespace ice_cream.Controllers
{
    public class HomeController : BaseController
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapRepsitory _mapRepsitory;

        public HomeController(IDbFactory dbFactory, IMapRepsitory mapRepsitory, CategoryRepository categoryRepository) : base(dbFactory)
        {
            this._categoryRepository = categoryRepository;
            this._mapRepsitory = mapRepsitory;

        }

        public ActionResult Index()
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                var book = session.Find<Book>();
                return View();
            }
        }
        public ActionResult Login()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult GetData()
        {
            using (var session = _dbFactory.Create<IAppSession>())
            {
                var test = _mapRepsitory.GetAll(session);
                return Json(new { xhr = test}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}