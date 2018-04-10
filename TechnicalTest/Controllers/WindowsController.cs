using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{
    [Produces("application/json")]
    public class WindowsController : Controller
    {
        public ActionResult GetWindows()
        {
            var api = new API();

            var windows = api.GetWindows();

            var response = new List<ResponseModel>();
            foreach (var window in windows)
            {
                var responseModel = new ResponseModel()
                {
                    Name = window.Name,
                    X = window.X,
                    Y = window.Y,
                    Width = window.Width,
                    Height = window.Height
                };

                response.Add(responseModel);
            }

            return new JsonResult(response);
        }

        [Route("windows/{name=name}")]
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