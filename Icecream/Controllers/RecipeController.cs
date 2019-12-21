using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Icecream.Models;

namespace Icecream.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListRecipe()
        {
            RecipeBLL bll = new RecipeBLL();
            List<Recipe> obj = new List<Recipe>();
            obj = bll.AllRecipeToList();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Recipe obj)
        {
            if (ModelState.IsValid)
            {
                RecipeBLL bll = new RecipeBLL();
                if (bll.Add(obj) == 0)
                {
                    return RedirectToAction("ListFreeRecipe", "Recipe");
                }

            }
            return View();
        }

        public ActionResult Update(int id)
        {
            var bll = new RecipeBLL();
            var dt = bll.GetRecipeByID(id);
            Recipe obj = new Recipe();

            obj.recipe_id = (int)dt.Rows[0]["recipe_id"];
            obj.title = dt.Rows[0]["title"].ToString();
            obj.description = dt.Rows[0]["description"].ToString();
            obj.detail = dt.Rows[0]["detail"].ToString();
            obj.image = dt.Rows[0]["image"].ToString();
            obj.author = dt.Rows[0]["author"].ToString();

            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(Recipe obj)
        {
            if (ModelState.IsValid)
            {
                RecipeBLL bll = new RecipeBLL();
                if (bll.Update(obj) == 0)
                {
                    return RedirectToAction("ListFreeRecipe", "Recipe");
                }
                else
                {
                    return View(obj);
                }

            }
            else
            {
                return View(obj);
            }
        }

        public ActionResult Details(int id)
        {
            var bll = new RecipeBLL();
            var dt = bll.GetRecipeByID(id);
            Recipe obj = new Recipe();

            obj.recipe_id = (int)dt.Rows[0]["recipe_id"];
            obj.title = dt.Rows[0]["title"].ToString();
            obj.description = dt.Rows[0]["description"].ToString();
            obj.detail = dt.Rows[0]["detail"].ToString();
            obj.image = dt.Rows[0]["image"].ToString();
            obj.author = dt.Rows[0]["author"].ToString();

            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var bll = new RecipeBLL();
            var dt = bll.GetRecipeByID(id);
            Recipe obj = new Recipe();

            obj.recipe_id = (int)dt.Rows[0]["recipe_id"];
            obj.title = dt.Rows[0]["title"].ToString();
            obj.description = dt.Rows[0]["description"].ToString();
            obj.detail = dt.Rows[0]["detail"].ToString();
            obj.image = dt.Rows[0]["image"].ToString();
            obj.author = dt.Rows[0]["author"].ToString();

            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(Recipe obj)
        {
            var bll = new RecipeBLL();
            var dt = bll.Delete(obj);

            return RedirectToAction("ListFreeRecipe", "Recipe");
        }
    }
}