using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HBS_Core.Controllers
{
    public class BookingController : Controller
    {
        private IBooking _ibooking;
        private Istaff _istaff;
        private IRoom _iroom;
        private IGust _igust;
        private IRoomClass _iroomclass;
        public BookingController(IBooking ibooking,Istaff istaff, IRoom iroom, IGust igust, IRoomClass iroomclass)
        {

            _ibooking = ibooking;
            _istaff = istaff;
            _iroom = iroom;
            _igust = igust;
            _iroomclass = iroomclass;
        }
        public IActionResult Index()
        {
            ViewBag.gust = _igust.GetAllGust();
            ViewBag.room = _iroom.GetAllRoom();
            ViewBag.roomclass = _iroomclass.GetAllRoomClass();
            
            var book = _ibooking.GetAllBooking();
            return View(book);
        }
        public IActionResult Details()
        {
            return View(_ibooking.GetAllBooking());
        }
            [HttpGet]
        public IActionResult Create()
        {
            ViewBag.GustID = new SelectList(_igust.GetAllGust(), "Id", "Name");
            ViewBag.RoomID = new SelectList(_iroom.GetAllRoom(), "Id", "Descrption");
            ViewBag.StaffID = new SelectList(_istaff.GetStaff(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Booking book)
        {
            _ibooking.Add(book);
            return View();

        }


        public IActionResult Edit(int id)
        {
            var book = _ibooking.GetBooking(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Booking book, int id)
        {
            var b = _ibooking.GetBooking(id);
            if (b.Id != id)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _ibooking.Update(book);
            }
            return RedirectToAction("Details");
        }


        public IActionResult Delete(int id)
        {
            return View(_ibooking.GetBooking(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection coo)
        {
            if (id == null)
            {
                return NotFound();
            }
            _ibooking.Delete(id);

            return RedirectToAction("Details");
        }
    }

}

