using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FillablePdfExample.Models
{
    public class Test1FormModel
    {
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Height")]
        public string Height { get; set; }        

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Driving License")]
        public bool DrivingLicense { get; set; }

        [Display(Name = "Deutsch")]
        public bool Lang1 { get; set; }

        [Display(Name = "English")]
        public bool Lang2 { get; set; }

        [Display(Name = "Français")]
        public bool Lang3 { get; set; }

        [Display(Name = "Esperanto")]
        public bool Lang4 { get; set; }

        [Display(Name = "Latin")]
        public bool Lang5 { get; set; }

        [Display(Name = "Favourite colour")]
        public string FavColor { get; set; }
    }
}