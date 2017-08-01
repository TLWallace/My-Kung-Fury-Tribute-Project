using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPNETFP_KungFuryNonFanSite.Models
{
    public class ContactFormModel /*TLW*/
    {
        [Required, Display(Name = "Share Your Name!")]
        public string FromName { get; set; }
        [Required, Display(Name = "Share Your Email!"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Share Your Ideas!")]
        public string Message { get; set; }
    }
}