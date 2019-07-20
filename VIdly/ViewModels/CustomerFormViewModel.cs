using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VIdly.Models;

namespace VIdly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customers { get; set; }
    }
}