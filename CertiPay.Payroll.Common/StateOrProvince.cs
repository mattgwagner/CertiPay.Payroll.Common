using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CertiPay.Payroll.Common
{
    public enum StateOrProvince : byte
    {
        Unknown = 0,

        [Display(Name = "Alabama")]
        AL = 1,

        [Display(Name = "Alaska")]
        AK = 2,

        [Display(Name = "American Samoa")]
        AS = 3,

        [Display(Name = "Arizona")]
        AZ = 4,

        [Display(Name = "Arkansas")]
        AR = 5,

        [Display(Name = "California")]
        CA = 6,

        [Display(Name = "Colorado")]
        CO = 7,

        [Display(Name = "Conneticut")]
        CT = 8,

        [Display(Name = "Delaware")]
        DE = 9,

        [Display(Name = "District of Columbia")]
        DC = 10,

        [Display(Name = "Federated States of Micronesia")]
        FM = 11,

        [Display(Name = "Florida")]
        FL = 12,

        [Display(Name = "Georgia")]
        GA = 13,

        [Display(Name = "Guam")]
        GU = 14,

        [Display(Name = "Hawaii")]
        HI = 15,

        [Display(Name = "Idaho")]
        ID = 16,

        [Display(Name = "Illinois")]
        IL = 17,

        [Display(Name = "Indiana")]
        IN = 18,

        [Display(Name = "Iowa")]
        IA = 19,

        [Display(Name = "Kansas")]
        KS = 20,

        [Display(Name = "Kentucky")]
        KY = 21,

        [Display(Name = "Louisiana")]
        LA = 22,

        [Display(Name = "Maine")]
        ME = 23,

        [Display(Name = "Marshall Islands")]
        MH = 24,

        [Display(Name = "Maryland")]
        MD = 25,

        [Display(Name = "Massachusetts")]
        MA = 26,

        [Display(Name = "Michigan")]
        MI = 27,

        [Display(Name = "Minnesota")]
        MN = 28,

        [Display(Name = "Mississippi")]
        MS = 29,

        [Display(Name = "Missouri")]
        MO = 30,

        [Display(Name = "Montana")]
        MT = 31,

        [Display(Name = "Nebraska")]
        NE = 32,

        [Display(Name = "Nevada")]
        NV = 33,

        [Display(Name = "New Hampshire")]
        NH = 34,

        [Display(Name = "New Jersey")]
        NJ = 35,

        [Display(Name = "New Mexico")]
        NM = 36,

        [Display(Name = "New York")]
        NY = 37,

        [Display(Name = "North Carolina")]
        NC = 38,

        [Display(Name = "North Dakota")]
        ND = 39,

        [Display(Name = "Northern Mariana Islands")]
        MP = 40,

        [Display(Name = "Ohio")]
        OH = 41,

        [Display(Name = "Oklahoma")]
        OK = 42,

        [Display(Name = "Oregon")]
        OR = 43,

        [Display(Name = "Palau")]
        PW = 44,

        [Display(Name = "Pennsylvania")]
        PA = 45,

        [Display(Name = "Puerto Rico")]
        PR = 46,

        [Display(Name = "Rhode Island")]
        RI = 47,

        [Display(Name = "South Carolina")]
        SC = 48,

        [Display(Name = "South Dakota")]
        SD = 49,

        [Display(Name = "Tennesse")]
        TN = 50,

        [Display(Name = "Texas")]
        TX = 51,

        [Display(Name = "Utah")]
        UT = 52,

        [Display(Name = "Vermont")]
        VT = 53,

        [Display(Name = "Virgin Islands")]
        VI = 54,

        [Display(Name = "Virginia")]
        VA = 55,

        [Display(Name = "Washington")]
        WA = 56,

        [Display(Name = "West Virginia")]
        WV = 57,

        [Display(Name = "Wisconsin")]
        WI = 58,

        [Display(Name = "Wyoming")]
        WY = 59
    }

    public static class States
    {
        /// <summary>
        /// Returns the list of States
        /// </summary>
        public static IEnumerable<StateOrProvince> Values()
        {
            foreach (var state in Enum.GetValues(typeof(StateOrProvince)))
            {
                yield return (StateOrProvince)state;
            }
        }

        /// <summary>
        /// Returns the state by either the abbreviation or display name
        /// </summary>
        public static StateOrProvince Parse(string value)
        {
            StateOrProvince state;

            if (!Enum.TryParse<StateOrProvince>(value, ignoreCase: true, result: out state))
            {
                state = GetStateByName(value);
            }

            return state;
        }

        /// <summary>
        /// Returns the state by the display name
        /// </summary>
        public static StateOrProvince GetStateByName(string name)
        {
            var value = from state in Values()
                        where String.Equals(state.Display(e => e.Name), name, StringComparison.CurrentCultureIgnoreCase)
                        select state;

            return value.SingleOrDefault();
        }

        /// <summary>
        /// Returns the Display Name for the StateOrProvince (i.e. FL -> Florida)
        /// </summary>
        public static String DisplayName(this StateOrProvince state)
        {
            return state.Display(e => e.Name);
        }

        private static String Display(this Enum val, Func<DisplayAttribute, String> selector)
        {
            FieldInfo fi = 
                val
                .GetType()
                .GetTypeInfo()
                .GetDeclaredField(val.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.CustomAttributes.OfType<DisplayAttribute>();

            if (attributes != null && attributes.Length > 0)
            {
                return selector.Invoke(attributes[0]);
            }

            return val.ToString();
        }
    }
}