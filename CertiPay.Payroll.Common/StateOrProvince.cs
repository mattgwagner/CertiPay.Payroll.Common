using CertiPay.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Payroll.Common
{
    public enum StateOrProvince : byte
    {
        [Display(Name = "Alabama")]
        AL,

        [Display(Name = "Alaska")]
        AK,

        [Display(Name = "American Samoa")]
        AS,

        [Display(Name = "Arizona")]
        AZ,

        [Display(Name = "Arkansas")]
        AR,

        [Display(Name = "California")]
        CA,

        [Display(Name = "Colorado")]
        CO,

        [Display(Name = "Conneticut")]
        CT,

        [Display(Name = "Delaware")]
        DE,

        [Display(Name = "District of Columbia")]
        DC,

        [Display(Name = "Federated States of Micronesia")]
        FM,

        [Display(Name = "Florida")]
        FL,

        [Display(Name = "Georgia")]
        GA,

        [Display(Name = "Guam")]
        GU,

        [Display(Name = "Hawaii")]
        HI,

        [Display(Name = "Idaho")]
        ID,

        [Display(Name = "Illinois")]
        IL,

        [Display(Name = "Indiana")]
        IN,

        [Display(Name = "Iowa")]
        IA,

        [Display(Name = "Kansas")]
        KS,

        [Display(Name = "Kentucky")]
        KY,

        [Display(Name = "Louisiana")]
        LA,

        [Display(Name = "Maine")]
        ME,

        [Display(Name = "Marshall Islands")]
        MH,

        [Display(Name = "Maryland")]
        MD,

        [Display(Name = "Massachusetts")]
        MA,

        [Display(Name = "Michigan")]
        MI,

        [Display(Name = "Minnesota")]
        MN,

        [Display(Name = "Mississippi")]
        MS,

        [Display(Name = "Missouri")]
        MO,

        [Display(Name = "Montana")]
        MT,

        [Display(Name = "Nebraska")]
        NE,

        [Display(Name = "Nevada")]
        NV,

        [Display(Name = "New Hampshire")]
        NH,

        [Display(Name = "New Jersey")]
        NJ,

        [Display(Name = "New Mexico")]
        NM,

        [Display(Name = "New York")]
        NY,

        [Display(Name = "North Carolina")]
        NC,

        [Display(Name = "North Dakota")]
        ND,

        [Display(Name = "Northern Mariana Islands")]
        MP,

        [Display(Name = "Ohio")]
        OH,

        [Display(Name = "Oklahoma")]
        OK,

        [Display(Name = "Oregon")]
        OR,

        [Display(Name = "Palau")]
        PW,

        [Display(Name = "Pennsylvania")]
        PA,

        [Display(Name = "Puerto Rico")]
        PR,

        [Display(Name = "Rhode Island")]
        RI,

        [Display(Name = "South Carolina")]
        SC,

        [Display(Name = "South Dakota")]
        SD,

        [Display(Name = "Tennesse")]
        TN,

        [Display(Name = "Texas")]
        TX,

        [Display(Name = "Utah")]
        UT,

        [Display(Name = "Vermont")]
        VT,

        [Display(Name = "Virgin Islands")]
        VI,

        [Display(Name = "Virginia")]
        VA,

        [Display(Name = "Washington")]
        WA,

        [Display(Name = "West Virginia")]
        WV,

        [Display(Name = "Wisconsin")]
        WI,

        [Display(Name = "Wyoming")]
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