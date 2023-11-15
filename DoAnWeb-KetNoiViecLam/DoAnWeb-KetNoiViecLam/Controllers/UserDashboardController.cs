using DoAnWeb_KetNoiViecLam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoAnWeb_KetNoiViecLam.Controllers
{
    public class UserDashboardController : Controller
    {
        private readonly DataContext _dataContext;

        public UserDashboardController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageServices()
        {
            var serviceList = _dataContext.ServiceInformations.ToList();
            return View(serviceList);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(ServiceInformation model)
        {
            if (ModelState.IsValid)
            {
                model.Status = "active";
                _dataContext.ServiceInformations.Add(model);
                _dataContext.SaveChanges();
                return RedirectToAction("ManageServices");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var service = _dataContext.ServiceInformations.Find(id);

            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost]
        public IActionResult EditService(ServiceInformation model)
        {
            if (ModelState.IsValid)
            {
                // Lấy đối tượng từ cơ sở dữ liệu
                var existingService = _dataContext.ServiceInformations.SingleOrDefault(s => s.ServiceID == model.ServiceID);

                if (existingService != null)
                {
                    // Cập nhật thông tin của đối tượng
                    existingService.ServiceTitle = model.ServiceTitle;
                    existingService.Price = model.Price;
                    existingService.Category = model.Category;
                    existingService.EnglishLevel = model.EnglishLevel;
                    existingService.ResponseTime = model.ResponseTime;
                    existingService.DeliveryTime = model.DeliveryTime;
                    existingService.Skills = model.Skills;
                    existingService.Address = model.Address;
                    existingService.ServiceDetail = model.ServiceDetail;
                    existingService.Status = "active"; // Không cần gán lại model.Status

                    // Lưu thay đổi vào cơ sở dữ liệu
                    try
                    {
                        _dataContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        // In ra lỗi để kiểm tra
                        Console.WriteLine(ex.Message);
                    }
                    return RedirectToAction("ManageServices");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteService(ServiceInformation model)
        {
            if (ModelState.IsValid)
            {
                var existingService = _dataContext.ServiceInformations.SingleOrDefault(s => s.ServiceID == model.ServiceID);
                if (existingService == null)
                {
                    return NotFound();
                }
                _dataContext.ServiceInformations.Remove(existingService);
                _dataContext.SaveChanges();

            return RedirectToAction("ManageServices");
            }
        }

    }
}
