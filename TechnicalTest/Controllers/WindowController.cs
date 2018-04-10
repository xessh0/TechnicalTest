using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{
    public class WindowController : Controller
    {
        public ActionResult GetWindows()
        {
            var api = new API();

            var windows = api.GetWindows();

            var response = new List<ResponseModel>();
            foreach (var window in windows)
            {
                var viewModel = new ResponseModel()
                {
                    Name = window.Name,
                    X = window.X,
                    Y = window.Y,
                    Width = window.Width,
                    Height = window.Height
                };

                response.Add(viewModel);
            }

            return new JsonResult(response);
        }

        
        public ActionResult GetWindow([FromQuery] string name)

        {
            if (name == null) return GetWindows();

            var api = new API();

            var window = api.GetWindowByName(name);
            if (window == null) return NotFound();

            var response = new ResponseModel()
            {
                Name = window.Name,
                X = window.X,
                Y = window.Y,
                Width = window.Width,
                Height = window.Height
            };

            return new JsonResult(response);
        }
    }

}
