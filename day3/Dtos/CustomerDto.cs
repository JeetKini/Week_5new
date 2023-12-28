using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlysProject.Models;

namespace VidlysProject.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
   [Required(ErrorMessage = "Please enter the customer name")]
        [StringLength(200)]
        public string Name { get; set; }
        public bool IsSuscribedToNewsletter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
     
        //[Min18YearsIfaMember]
        public DateTime BirthDate { get; set; }
    }
}