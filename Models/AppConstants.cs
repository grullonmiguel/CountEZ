﻿using System.ComponentModel;

namespace CountEZ.Models
{
    #region Enums

    public enum AppTheme
    {
        Default,
        Dark,
        Light
    }

    /// <summary>
    /// The Bid Process Code
    /// </summary>
    public enum BidProcessCode
    {
        Unknown = 0,
        [Description("Auction")] Auction = 1,
        [Description("Premium")] Premium = 2,
        [Description("Bid Down")] BidDown = 3,
        [Description("Sealed Bid")] SealedBid = 4,
        [Description("Rotational Bid")] RotationalBid = 5
    }

    /// <summary>
    /// The Bid Process Code
    /// </summary>
    public enum SaleTypeCode
    {
        Unknown = 0,
        [Description("Hybrid")] Hybrid = 1,
        [Description("Tax Deed")] TaxDeed = 2,
        [Description("Tax Lien")] TaxLien = 3,
        [Description("Redeemable Deed")] RedeemableDeed = 4
    }

    /// <summary>
    /// States of the US
    /// </summary>
    public enum StateCode
    {
        [Description("Alabama")] AL = 1,
        [Description("Alaska")] AK = 2,
        [Description("Arkansas")] AR = 3,
        [Description("Arizona")] AZ = 4,
        [Description("California")] CA = 5,
        [Description("Colorado")] CO = 6,
        [Description("Connecticut")] CT = 7,
        [Description("District of Columbia")] DC = 8,
        [Description("Delaware")] DE = 9,
        [Description("Florida")] FL = 10,
        [Description("Georgia")] GA = 11,
        [Description("Hawaii")] HI = 12,
        [Description("Iowa")] IA = 13,
        [Description("Idaho")] ID = 14,
        [Description("Illinois")] IL = 15,
        [Description("Indiana")] IN = 16,
        [Description("Kansas")] KS = 17,
        [Description("Kentucky")] KY = 18,
        [Description("Louisiana")] LA = 19,
        [Description("Massachusetts")] MA = 20,
        [Description("Maryland")] MD = 21,
        [Description("Maine")] ME = 22,
        [Description("Michigan")] MI = 23,
        [Description("Minnesota")] MN = 24,
        [Description("Missouri")] MO = 25,
        [Description("Mississippi")] MS = 26,
        [Description("Montana")] MT = 27,
        [Description("North Carolina")] NC = 28,
        [Description("North Dakota")] ND = 29,
        [Description("Nebraska")] NE = 30,
        [Description("New Hampshire")] NH = 31,
        [Description("New Jersey")] NJ = 32,
        [Description("New Mexico")] NM = 33,
        [Description("Nevada")] NV = 34,
        [Description("New York")] NY = 35,
        [Description("Oklahoma")] OK = 36,
        [Description("Ohio")] OH = 37,
        [Description("Oregon")] OR = 38,
        [Description("Pennsylvania")] PA = 39,
        [Description("Rhode Island")] RI = 40,
        [Description("South Carolina")] SC = 41,
        [Description("South Dakota")] SD = 42,
        [Description("Tennessee")] TN = 43,
        [Description("Texas")] TX = 44,
        [Description("Utah")] UT = 45,
        [Description("Virginia")] VA = 46,
        [Description("Vermont")] VT = 47,
        [Description("Washington")] WA = 48,
        [Description("Wisconsin")] WI = 49,
        [Description("West Virginia")] WV = 50,
        [Description("Wyoming")] WY = 51
    }

    #endregion

    internal static class AppConstants
    {
        
    }
}
