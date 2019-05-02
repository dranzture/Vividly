using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vividly.Models;

namespace Vividly.View_Models
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}