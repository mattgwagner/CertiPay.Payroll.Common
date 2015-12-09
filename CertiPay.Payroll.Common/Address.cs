using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Represents a basic address format for the United States
    /// </summary>
    [ComplexType]
    public class Address
    {
        // Warning: This is marked as a complex type, and used in several projects, so any changes will trickle down into EF changes...

        /// <summary>
        /// The first line of the address
        /// </summary>
        [StringLength(75)]
        public String Address1 { get; set; }

        /// <summary>
        /// The second line of the address
        /// </summary>
        [StringLength(75)]
        public String Address2 { get; set; }

        /// <summary>
        /// The third line of the address
        /// </summary>
        [StringLength(75)]
        public String Address3 { get; set; }

        /// <summary>
        /// The city the address is located in
        /// </summary>
        [StringLength(50)]
        public String City { get; set; }

        /// <summary>
        /// The state the address is located in
        /// </summary>
        public StateOrProvince State { get; set; }

        /// <summary>
        /// The postal "zip" code for the address, could include the additional four digits
        /// </summary>
        [DataType(DataType.PostalCode)]
        [StringLength(15)]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        public Address()
        {
            this.State = StateOrProvince.FL;
        }
    }
}