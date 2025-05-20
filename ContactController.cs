using System.Web.Mvc;

namespace YourApp.Controllers
{
    public class ContactController : Controller
    {
        // Hiển thị trang liên hệ
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Xử lý gửi thông tin liên hệ
        [HttpPost]
        public ActionResult Send(string Name, string Email, string Message)
        {
            // TODO: xử lý gửi email hoặc lưu vào database

            TempData["Success"] = "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi sớm.";
            return RedirectToAction("Index");
        }
    }
}
