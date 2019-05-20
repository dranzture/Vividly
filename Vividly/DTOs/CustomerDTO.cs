using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vividly.Models;

namespace Vividly.DTOs
{
    public class CustomerDTO
    {
        [Required]
        public int ID { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        //[Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeID { get; set; }
    }
}