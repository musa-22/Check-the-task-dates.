using Microsoft.AspNetCore.Mvc;
using Reminder.DATA;
using Reminder.Model;
using System.Globalization;

namespace Reminder.Controllers
{
    public class ReminderController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ReminderController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {

            //.Where(u =>u.leftDays <30)
            var getAll = _context.detailsDb.ToList();

            foreach (var details in getAll)
            {
                details.leftDays = (details.endData - DateTime.Now).Days;
            
            }

             
            //To update the date when a page is refreshed,
            _context.SaveChanges();

            return View(getAll);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(string goal, string startData, string endData)
        {
            string[] dateFormats = { "dd/MM/yyyy", "yyyy-MM-dd" };
            DateTime checkStartDate;
            DateTime checkEndDate;

            if (DateTime.TryParseExact(startData, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out checkStartDate) &&
                DateTime.TryParseExact(endData, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out checkEndDate))
            {

                int totalDays = (checkEndDate - checkStartDate).Days;

                Details details = new Details()
                {
                    Goal = goal,
                    startData = checkStartDate,
                    endData = checkEndDate,
                    leftDays = (checkEndDate - checkStartDate).Days,
                    
                   totalDay = totalDays,
                    

            };

                _context.Add(details);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                
                return View();
            }
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {

         var model = _context.detailsDb.Find(id);



            return View(model);
        }


        public IActionResult Edit(int id, string goal, string startData, string endData)
        {
           
            var detailsToUpdate = _context.detailsDb.Find(id);

          

         
            string[] dateFormats = { "dd/MM/yyyy", "yyyy-MM-dd" };
            DateTime checkStartDate;
            DateTime checkEndDate;

            if (!DateTime.TryParseExact(startData, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out checkStartDate) ||
                !DateTime.TryParseExact(endData, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out checkEndDate))
            {
              
                return View();
            }
      
          
            // Update details 
            detailsToUpdate.Goal = goal;
            detailsToUpdate.startData = checkStartDate;
            detailsToUpdate.endData = checkEndDate;
                detailsToUpdate.totalDay = (checkEndDate - checkStartDate).Days;
            // Recalculate leftDays
            detailsToUpdate.leftDays = (detailsToUpdate.endData.Date - DateTime.Now.Date).Days;
           
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {

            var model = _context.detailsDb.Find(id);



            return View(model);
        }



        [HttpPost]
        public IActionResult Delete(Details obj)
        {

            var model = _context.detailsDb.Find(obj.Id);


            _context.detailsDb.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}

