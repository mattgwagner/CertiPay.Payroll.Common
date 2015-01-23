using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CertiPay.Payroll.Common
{
    public enum StateOrProvince : byte
    {
        [Description("Alabama")]
        AL,

        [Description("Alaska")]
        AK,

        [Description("American Samoa")]
        AS,

        [Description("Arizona")]
        AZ,

        [Description("Arkansas")]
        AR,

        [Description("California")]
        CA,

        [Description("Colorado")]
        CO,

        [Description("Conneticut")]
        CT,

        [Description("Delaware")]
        DE,

        [Description("District of Columbia")]
        DC,

        [Description("Federated States of Micronesia")]
        FM,

        [Description("Florida")]
        FL,

        [Description("Georgia")]
        GA,

        [Description("Guam")]
        GU,

        [Description("Hawaii")]
        HI,

        [Description("Idaho")]
        ID,

        [Description("Illinois")]
        IL,

        [Description("Indiana")]
        IN,

        [Description("Iowa")]
        IA,

        [Description("Kansas")]
        KS,

        [Description("Kentucky")]
        KY,

        [Description("Louisiana")]
        LA,

        [Description("Maine")]
        ME,

        [Description("Marshall Islands")]
        MH,

        [Description("Maryland")]
        MD,

        [Description("Massachusetts")]
        MA,

        [Description("Michigan")]
        MI,

        [Description("Minnesota")]
        MN,

        [Description("Mississippi")]
        MS,

        [Description("Missouri")]
        MO,

        [Description("Montana")]
        MT,

        [Description("Nebraska")]
        NE,

        [Description("Nevada")]
        NV,

        [Description("New Hampshire")]
        NH,

        [Description("New Jersey")]
        NJ,

        [Description("New Mexico")]
        NM,

        [Description("New York")]
        NY,

        [Description("North Carolina")]
        NC,

        [Description("North Dakota")]
        ND,

        [Description("Northern Mariana Islands")]
        MP,

        [Description("Ohio")]
        OH,

        [Description("Oklahoma")]
        OK,

        [Description("Oregon")]
        OR,

        [Description("Palau")]
        PW,

        [Description("Pennsylvania")]
        PA,

        [Description("Puerto Rico")]
        PR,

        [Description("Rhode Island")]
        RI,

        [Description("South Carolina")]
        SC,

        [Description("South Dakota")]
        SD,

        [Description("Tennesse")]
        TN,

        [Description("Texas")]
        TX,

        [Description("Utah")]
        UT,

        [Description("Vermont")]
        VT,

        [Description("Virgin Islands")]
        VI,

        [Description("Virginia")]
        VA,

        [Description("Washington")]
        WA,

        [Description("West Virginia")]
        WV,

        [Description("Wisconsin")]
        WI,

        [Description("Wyoming")]
        WY
    }

    public static class States
    {
        public static IEnumerable<StateOrProvince> Values()
        {
            foreach (var state in Enum.GetValues(typeof(StateOrProvince)))
            {
                yield return (StateOrProvince)state;
            }
        }

        public static StateOrProvince GetStateByName(string name)
        {
            var value = from state in Values()
                        where String.Equals(state.DisplayName(), name, StringComparison.InvariantCultureIgnoreCase)
                        select state;

            return value.SingleOrDefault();
        }
    }
}