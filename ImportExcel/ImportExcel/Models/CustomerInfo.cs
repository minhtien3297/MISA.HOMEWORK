using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcel.Models
{
    public class CustomerInfo
    {
        public string CustomeCode { get; set; }
        public string CustomerName { get; set; }
        public string MemberCardCode { get; set; }
        public string CustomerGroup { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public int TaxCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    }
}