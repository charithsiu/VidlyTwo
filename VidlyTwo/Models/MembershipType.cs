using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyTwo.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string MembershipName { get; set; }

        public int SingUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayasYouGo = 1;
    }
}