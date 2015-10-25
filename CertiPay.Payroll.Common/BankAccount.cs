using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertiPay.Payroll.Common
{
    [ComplexType]
    public class BankAccount
    {
        /// <summary>
        /// The 9-digit routing number that identifies the financial institution that manages the account
        /// </summary>
        [Display(Name = "Routing Number", ShortName = "MICR #")]
        [StringLength(9)]
        public String RoutingNumber { get; set; }

        /// <summary>
        /// Up to 17-digit number that identifies a specific account at a financial institution.
        /// NACHA allows up to 17 in their feed spec, but most are ~8-10
        /// </summary>
        [Display(Name = "Account Number", ShortName = "Acct #")]
        [StringLength(17)]
        public String AccountNumber { get; set; }

        /// <summary>
        /// True if the bank account is a savings account rather than a checking account
        /// </summary>
        [Display(Name = "Is Savings?")]
        public Boolean IsSavings { get; set; }

        /// <summary>
        /// Returns true if the number provided passes the checksum validation for routing numbers
        /// </summary>
        public static Boolean IsValidRoutingNumber(String routingNumber)
        {
            //The MICR number is of the form: XXXXYYYYC where XXXX is Federal Reserve Routing Symbol, YYYY is ABA Institution Identifier, and C is the Check Digit

            if (!String.IsNullOrWhiteSpace(routingNumber) && routingNumber.Length == 9)
            {
                String fedReserveRoutingSymbol = routingNumber.Substring(0, 4);

                //The first two digits of the nine digit RTN must be in the ranges 00 through 12, 21 through 32, 61 through 72, or 80.

                //The digits are assigned as follows:

                //00 is used by the United States Government
                //01 through 12 are the "normal" routing numbers, and correspond to the 12 Federal Reserve Banks.For example, 0260 - 0959 - 3 is the routing number for Bank of America incoming wires in New York, with the initial "02" indicating the Federal Reserve Bank of New York.
                //21 through 32 were assigned only to thrift institutions(e.g.credit unions and savings banks) through 1985, but are no longer assigned(thrifts are assigned normal 01–12 numbers).Currently they are still used by the thrift institutions, or their successors, and correspond to the normal routing number, plus 20. (For example, 2260 - 7352 - 3 is the routing number for Grand Adirondack Federal Credit Union in New York, with the initial "22" corresponding to "02"(New York Fed) plus "20"(thrift).)
                //61 through 72 are special purpose routing numbers designated for use by non - bank payment processors and clearinghouses and are termed Electronic Transaction Identifiers(ETIs), and correspond to the normal routing number, plus 60.
                //80 is used for traveler's cheques

                String abaIdentifier = routingNumber.Substring(4, 4);

                String checkDigit = routingNumber.Substring(8, 1);

                // The ninth, check digit provides a checksum test using a position-weighted sum of each of the digits.
                // High - speed check - sorting equipment will typically verify the checksum and if it fails, route the item
                // to a reject pocket for manual examination, repair, and re - sorting.Mis - routings to an incorrect bank are thus greatly reduced.

                int section_one = 3 * (int.Parse(routingNumber[0] + "") + int.Parse(routingNumber[3] + "") + int.Parse(routingNumber[6] + ""));

                int section_two = 7 * (int.Parse(routingNumber[1] + "") + int.Parse(routingNumber[4] + "") + int.Parse(routingNumber[7] + ""));

                int section_three = 1 * (int.Parse(routingNumber[2] + "") + int.Parse(routingNumber[5] + "") + int.Parse(routingNumber[8] + ""));

                return ((section_one + section_two + section_three) % 10) == 0;
            }

            return false;
        }
    }
}