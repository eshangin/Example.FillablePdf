using FillablePdfExample.Models;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FillablePdfExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FillPdf(Test1FormModel model)
        {
            using (var ms = new MemoryStream())
            {
                using (PdfReader pdfReader = new PdfReader(Server.MapPath("~/pdf-templates/test1.pdf")))
                using (PdfStamper pdfStamper = new PdfStamper(pdfReader, ms))
                {
                    AcroFields fields = pdfStamper.AcroFields;

                    // In case FormFlattening=True Fields become empty without this flag
                    fields.GenerateAppearances = true;

                    fields.SetField("Given Name Text Box", model.GivenName ?? string.Empty);
                    fields.SetField("Family Name Text Box", model.FamilyName ?? string.Empty);
                    fields.SetField("Address 1 Text Box", model.Address1 ?? string.Empty);
                    fields.SetField("Address 2 Text Box", model.Address2 ?? string.Empty);
                    fields.SetField("House nr Text Box", model.HouseNumber ?? string.Empty);
                    fields.SetField("Postcode Text Box", model.Postcode ?? string.Empty);
                    fields.SetField("City Text Box", model.City ?? string.Empty);
                    fields.SetField("Country Combo Box", model.Country ?? string.Empty);
                    fields.SetField("Gender List Box", model.Gender ?? string.Empty);
                    fields.SetField("Height Formatted Field", model.Height ?? string.Empty);
                    SetCheckboxValue(fields, "Driving License Check Box", model.DrivingLicense);
                    SetCheckboxValue(fields, "Language 1 Check Box", model.Lang1);
                    SetCheckboxValue(fields, "Language 2 Check Box", model.Lang2);
                    SetCheckboxValue(fields, "Language 3 Check Box", model.Lang3);
                    SetCheckboxValue(fields, "Language 4 Check Box", model.Lang4);
                    SetCheckboxValue(fields, "Language 5 Check Box", model.Lang5);
                    fields.SetField("Favourite Colour List Box", model.FavColor ?? string.Empty);

                    pdfStamper.FormFlattening = true;
                }

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = "result.pdf",
                    Inline = true,
                };
                Response.AddHeader("Content-Disposition", cd.ToString());
                return File(ms.ToArray(), "application/pdf");
            }
        }

        private static void SetCheckboxValue(AcroFields fields, string fieldName, bool val)
        {
            var states = fields.GetAppearanceStates(fieldName);
            fields.SetField(fieldName, val ? states.FirstOrDefault(s => s != "Off") : states.FirstOrDefault(s => s == "Off"), true);
            //fields.SetField(fieldName, "Anemia");
        }
    }
}