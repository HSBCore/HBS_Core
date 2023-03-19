using BOL.Data;
using BOL;
using Microsoft.AspNetCore.Mvc;

namespace HBS_Core.Controllers
{
    public class RoomClassController : Controller
    {
        private IRoomClass _iroomclass;
        public RoomClassController(IRoomClass iroomclass)
        {
            _iroomclass = iroomclass;
        }

        public IActionResult Index()
        {
            return View(_iroomclass.GetAllRoomClass());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomClass roomclass)
        {
            _iroomclass.Add(roomclass);
            return RedirectToAction("Index");

        }


        public IActionResult Edit(int id)
        {
            var roomclass = _iroomclass.GetRoomClass(id);
            return View(roomclass);
        }

        [HttpPost]
        public IActionResult Edit(RoomClass roomclass, int id)
        {
            
                _iroomclass.Update(roomclass);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            return View(_iroomclass.GetRoomClass(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection coo)
        {
            if (id == null)
            {
                return NotFound();
            }

            _iroomclass.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
