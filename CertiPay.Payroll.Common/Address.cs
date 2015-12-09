using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertiPay.Payroll.Common
{
    [ComplexType]
    public class Address
    {
        // Warning: This is marked as a complex type, and used in several projects, so any changes will trickle down into EF changes...

        [StringLength(75)]
        public String Address1 { get; set; }

        [StringLength(75)]
        public String Address2 { get; set; }

        [StringLength(75)]
        public String Address3 { get; set; }

        [StringLength(50)]
        public String City { get; set; }

        public StateOrProvince State { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(15)]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        // TODO: international fields

        public Address()
        {
            this.State = StateOrProvince.FL;
        }
    }
}