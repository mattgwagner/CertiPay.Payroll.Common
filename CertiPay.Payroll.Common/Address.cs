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
        public StateOrProvince State { get; set; } = StateOrProvince.Unknown;

        /// <summary>
        /// The postal "zip" code for the address, could include the additional four digits
        /// </summary>
        [DataType(DataType.PostalCode)]
        [StringLength(15)]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        public static bool operator ==(Address Left, Address Right)
        {
            if (ReferenceEquals(Left, Right)) return true;

            if ((object)Left == null || (object)Right == null) return false;

            Func<String, String, Boolean> eq = (left, right) =>
            {
                // In this case, we'll say that things like Address2 being null on one side and "" on the other are good enough

                return String.Equals(left ?? String.Empty, right ?? String.Empty, StringComparison.OrdinalIgnoreCase);
            };

            return eq(Left.Address1, Right.Address1) && eq(Left.Address2, Right.Address2) && eq(Left.Address3, Right.Address3) && eq(Left.City, Right.City) && eq(Left.PostalCode, Right.PostalCode) && Left.State == Right.State;
        }

        public static bool operator !=(Address Left, Address Right)
        {
            return !(Left == Right);
        }

        /// <summary>
        /// Determines if two addresses are equal, by comparing each property (ignoring case) to its counterpart.
        /// </summary>
        public override bool Equals(Object obj)
        {
            Address other = obj as Address;

            return other != null && (other == this);
        }
    }
}