using ChartsExample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartsExample.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult StackedBarChart()
        {
            var viewModel = GenerateRandomChartData();

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult RefreshData(DateTime start, DateTime end)
        {
            //this would be where I get data from the accommodation services or an SP (may be quicker)
            //here just randomise an object
            StackedViewModel chartData = GenerateRandomChartData();

            RefreshedDataModel model = new RefreshedDataModel() {
                XStackLabels = chartData.Stacks.FirstOrDefault().LstData.Select(x => x.SingleBar).ToList(),
                YValues = chartData.Stacks.Select(x => x.LstData.Select(w => w.Quantity)).ToList(),
                XLabels = chartData.Stacks.Select(x => x.StackedBar).ToList()
            };

            return Json(model);
        }

        private StackedViewModel GenerateRandomChartData()
        {
            Random rnd = new Random();
            var viewModel = new StackedViewModel();
            var model = new List<SingleBarViewModel>();

            viewModel.StartDate = DateTime.Now;
            viewModel.EndDate = DateTime.Now.AddDays(25);

            string[] buildings = new[] { "Walnut", "Beech", "Maple", "Oak", "Acacia", "Jacaranda" };
            var roomSts = new List<string>() { "Active", "Provisional", "Void" };

            for (var i = 0; i < 6; i++)
            {
                viewModel.Stacks.Add(new Stack
                {
                    StackedBar = buildings[i],
                    LstData = new List<SingleBarViewModel>
                    {
                        new SingleBarViewModel
                        {
                            SingleBar = "Active",
                            Quantity = rnd.Next(10) // _service.CalculateActives(building[i])
                        },
                        new SingleBarViewModel
                        {
                            SingleBar = "Provisional",
                            Quantity = rnd.Next(10) // _service.CalculateProvisionals(building[i])
                        },
                        new SingleBarViewModel
                        {
                            SingleBar = "Void",
                            Quantity = rnd.Next(10) //_service.calculateVoids(building[i])
                        }
                    }
                });
            };

            return viewModel;
        }
    }
}
