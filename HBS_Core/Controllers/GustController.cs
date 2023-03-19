using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Mvc;

namespace HBS_Core.Controllers
{
    public class GustController : Controller
    {
        private IGust _igust;
        public GustController(IGust igust)
        {

            _igust = igust;
        }
        public IActionResult Index()
        {
            return View(_igust.GetAllGust());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gust gust)
        {
            _igust.Add(gust);
            return RedirectToAction("Index");

        }


        public IActionResult Edit(int id)
        {
            var gust = _igust.GetGust(id);
            return View(gust);
        }

        [HttpPost]
        public IActionResult Edit(Gust gust, int id)
        {
            //var g = _igust.GetGust(id);
            //if (g.Id != id)
            //{
            //    return RedirectToAction("Index");
            //}
            _igust.Update(gust);

            return RedirectToAction("index");
        }


        public IActionResult Delete(int id)
        {
            return View(_igust.GetGust(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection coo)
        {
            if (id == null)
            {
                return NotFound();
            }

            _igust.Delete(id);

            return RedirectToAction("index");
        }
    }
}
