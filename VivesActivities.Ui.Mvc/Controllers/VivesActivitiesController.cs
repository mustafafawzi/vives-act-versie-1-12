using Microsoft.AspNetCore.Mvc;
using VivesActivities.Model;
using VivesActivities.Services;

namespace VivesActivities.Ui.Mvc.Controllers
{
    public class VivesActivitiesController(VivesActivityService activityService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var activities = activityService.Find();
            return View(activities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VivesActivity activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }

            activityService.Create(activity);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var activity = activityService.Get(id);

            if (activity is null)
            {
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VivesActivity activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }

            activityService.Update(id, activity);

            return RedirectToAction("Index");
        }
    }
}
