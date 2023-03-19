using BOL.Data;
using BOL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HBS_Core.Controllers
{
    public class RoomController : Controller
    {
        private IRoom _iroom;
        private IRoomClass _iroomclass;
        public RoomController(IRoom iroom, IRoomClass iroomclass)
        {
            _iroom = iroom;
            _iroomclass = iroomclass;
        }

        public IActionResult Index()
        {
            return View(_iroom.GetAllRoom());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.RoomClassID = new SelectList(_iroomclass.GetAllRoomClass(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Room room)
        {
            _iroom.Add(room);
            return RedirectToAction("Index");

        }


        public IActionResult Edit(int id)
        {
            var room = _iroom.GetRoom(id);
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(Room room, int id)
        {
            
                _iroom.Update(room);
            
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            return View(_iroom.GetRoom(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection coo)
        {
            if (id == null)
            {
                return NotFound();
            }
            _iroom.Delete(id);

            return RedirectToAction("Index");
        }
        
    }
}
