using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Ordina.PaymentRequest.Models
{
    public class PaymentRequest
    {
        [Required]
        [Key]
        [Display(Name = "Titel")]
        public String Title { get; set; }
        [Required]
        [Display(Name = "Naam")]
        public String FullName { get; set; }
        [Required]
        [Display(Name = "Bedrag")]
        public String Amount { get; set; }
        [Required]
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Omschrijving")]
        public String Description { get; set; }
        //[Display(Name = "RequestId")]
        //[DataMember]
        //public String RequestId { get; set; }
    }
}