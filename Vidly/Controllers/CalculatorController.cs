using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Vidly.Models;


namespace Vidly.Controllers
{

    public class CalculatorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CalculatorModel obj = new CalculatorModel();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel model)
        {
            try
            {
                switch (model.Operation)
                {
                    case "Add":
                        model.Result = model.Number1 + model.Number2;
                        break;
                    case "Subtract":
                        model.Result = model.Number1 - model.Number2;
                        break;
                    case "Multiply":
                        model.Result = model.Number1 * model.Number2;
                        break;
                    case "Divide":
                        if (model.Number2 == 0)
                        {
                            model.ErrorMessage = "Cannot divide by zero.";
                        }
                        else
                        {
                            model.Result = model.Number1 / model.Number2;
                        }
                        break;
                    default:
                        model.ErrorMessage = "Invalid operation.";
                        break;
                }
            }
            catch (Exception ex)
            {
                model.ErrorMessage = "An error occurred: " + ex.Message;
            }

            return View(model);
        }
    }

}

