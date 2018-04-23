using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using E5040.Reports;

namespace E5040.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";

            return View();
        }

        public ActionResult CallbackPanelPartial(string fieldName, bool isShiftKeyPressed) {
            ProductsReport.SortBy(fieldName, isShiftKeyPressed);
            return PartialView("_CallbackPanelPartial");
        }

        public ActionResult DocumentViewerPartial() {
            ProductsReport report = new ProductsReport();
            return PartialView("_DocumentViewerPartial", report);
        }

        public ActionResult DocumentViewerExport() {
            ProductsReport report = new ProductsReport();
            return ReportViewerExtension.ExportTo(report);
        }
    }
}