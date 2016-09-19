using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace CertiPay.Payroll.Common
{
    /// <summary>
    /// Represents a phone number for a company, department, user, or employee
    /// </summary>
    [ComplexType]
    public class PhoneNumber
    {
        private String _number = String.Empty;

        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public String Number
        {
            get { return _number; }
            set
            {
                // Strip out non-digit characters when setting

                char[] arr = (value ?? String.Empty).ToCharArray();

                arr = arr.Where(c => char.IsDigit(c)).ToArray();

                _number = new string(arr);
            }
        }

        [StringLength(10)]
        public String Extension { get; set; }

        public PhoneType PhoneType { get; set; }

        public PhoneNumber()
        {
            this.PhoneType = PhoneType.Default;
        }

        public override string ToString()
        {
            if (String.IsNullOrWhiteSpace(Number)) return String.Empty;

            String output = Number;

            // This might be tweaked based on real data

            String extension = String.IsNullOrWhiteSpace(Extension) ? String.Empty : "ext" + Extension + " ";

            return String.Format("{0} {1}({2})",
                FormatPhoneNumber(Number, out output) ? output : Number,
                extension,
                PhoneType);
        }

        /// <summary>
        /// Very basic formatting for phone numbers including area code to format 123-456-7890.
        /// Will not attempt to format phone numbers with a leading 1 i.e. 1-800-123-456-7890
        /// or extensions
        /// </summary>
        internal static Boolean FormatPhoneNumber(String input, out String output)
        {
            output = String.Empty;

            // This is the regex Microsoft uses in the [Phone] attribute

            // new Regex(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

            // http://blog.stevenlevithan.com/archives/validate-phone-number

            Regex regexObj = new Regex(@"^\(?([0-9]{3,4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            if (regexObj.IsMatch(input))
            {
                output = regexObj.Replace(input, "($1) $2-$3");
            }

            // Invalid phone number
            return !String.IsNullOrWhiteSpace(output);
        }
    }

    public enum PhoneType : byte
    {
        /// <summary>
        /// The phone type is not specified
        /// </summary>
        Default = 0,

        Home = 1,

        Work = 2,

        Mobile = 3,

        Fax = 4
    }
}