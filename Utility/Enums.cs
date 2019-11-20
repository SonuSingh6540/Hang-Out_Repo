using System.ComponentModel;

namespace Utility
{
    public enum UserType
    {
        [Description("SuperAdmin")]
        SUPER_ADMIN = 1,
        [Description("Admin")]
        ADMIN = 2,
        [Description("Teacher")]
        TEACHER = 3
    }
    public enum Gender
    {
        [Description("Male")]
        Male = 0,
        [Description("Female")]
        Female = 1,
    }
    public enum ContentType
    {
        [Description("About")]
        About = 1,
        [Description("Term&Condition")]
        TermAndCondition = 2,
        [Description("DebateTopic")]
        DebateTopic = 3,
        [Description("DebateWinner")]
        DebateWinner = 4,
        [Description("AddMember")]
        AddMember = 5,
        [Description("InnovativeIdea")]
        InnovativeIdea = 6,
        [Description("Advertisement")]
        Advertisement = 7,
    }
    public enum CountryCode
    {
        Afghanistan = 228,
        Saint_Lucia = 230,
        Samoa = 6,
        San_Marino = 7,
        Albania = 9,
        Algeria = 10,
        American_Samoa = 11,
        Andorra = 12,
        Angola = 13,
        Anguilla = 14,
        Antarctica = 15,
        Argentina = 17,
        Armenia = 18,
        Aruba = 19,
        Australia = 20,
        Austria = 21,
        Azerbaijan = 22,
        Bahamas = 23,
        Bahrain = 24,
        Bangladesh = 25,
        Barbados = 26,
        Belarus = 27,
        Belgium = 28,
        Belize = 29,
        Benin = 30,
        Bermuda = 31,
        Bhutan = 32,
        Bolivia = 33,
        Botswana = 35,
        Brazil = 37,
        Bulgaria = 40,
        Burundi = 42,
        Cambodia = 43,
        Cameroon = 44,
        Canada = 45,
        Chad = 49,
        Chile = 50,
        China = 51,
        Colombia = 54,
        Comoros = 55,
        Congo = 56,
        Croatia = 61,
        Cuba = 62,
        Cyprus = 63,
        Czech_Republic = 64,
        Denmark = 65,
        Djibouti = 66,
        Dominica = 67,
        Dominican_Republic = 68,
        Ecuador = 69,
        Egypt = 70,
        Eritrea = 73,
        Estonia = 74,
        Ethiopia = 75,
        Fiji = 78,
        Finland = 79,
        France = 80,
        Guiana = 81,
        Gabon = 84,
        Gambia = 85,
        Georgia = 86,
        Germany = 87,
        Ghana = 88,
        Gibraltar = 89,
        Greece = 90,
        Greenland = 91,
        Grenada = 92,
        Guadeloupe = 93,
        Guam = 94,
        Guatemala = 95,
        Guinea = 96,
        Guyana = 98,
        Haiti = 99,
        Honduras = 102,
        Hong_Kong = 103,
        Hungary = 104,
        Iceland = 105,
        India = 1,
        Indonesia = 107,
        Iraq = 109,
        Ireland = 110,
        Israel = 111,
        Italy = 112,
        Jamaica = 113,
        Japan = 114,
        Jordan = 115,
        Kazakhstan = 116,
        Kenya = 117,
        Kiribati = 118,
        Korea = 119,
        Kuwait = 122,
        Kyrgyzstan = 123,
        Lebanon = 126,
        Lesotho = 127,
        Liberia = 128,
        Liechtenstein = 130,
        Lithuania = 131,
        Luxembourg = 132,
        Macao = 133,
        Macedonia = 134,
        Madagascar = 136,
        Malawi = 137,
        Malaysia = 138,
        Maldives = 139,
        Mali = 140,
        Malta = 141,
        Martinique = 143,
        Mauritania = 144,
        Mauritius = 145,
        Mayotte = 146,
        Mexico = 147,
        Micronesia = 148,
        Moldova = 150,
        Mongolia = 151,
        Montserrat = 152,
        Morocco = 153,
        Mozambique = 154,
        Myanmar = 155,
        Namibia = 156,
        Nauru = 157,
        Nepal = 158,
        Netherlands = 159,
        Nicaragua = 163,
        Niger = 164,
        Nigeria = 165,
        Niue = 166,
        Norway = 169,
        Oman = 170,
        Pakistan = 171,
        Palau = 172,
        Panama = 174,
        Paraguay = 176,
        Peru = 177,
        Philippines = 178,
        Pitcairn = 179,
        Poland = 180,
        Portugal = 181,
        Qatar = 183,
        Reunion = 184,
        Romania = 185,
        Rwanda = 187,
        Saudi_Arabia = 189,
        Senegal = 190,
        Seychelles = 192,
        Singapore = 194,
        Slovakia = 195,
        Slovenia = 196,
        Somalia = 198,
        South_Africa = 199,
        Spain = 200,
        SriLanka = 201,
        Sudan = 202,
        Suriname = 203,
        Swaziland = 205,
        Sweden = 206,
        Switzerland = 207,
        Arab_Republic = 208,
        Taiwan = 209,
        Tajikistan = 210,
        Tanzania = 211,
        Thailand = 212,
        Turkey = 213,
        Turkmenistan = 214,
        Tuvalu = 215,
        Uganda = 216,
        Ukraine = 217,
        UAE = 218,
        UK = 3,
        US = 2,
        Uruguay = 220,
        Uzbekistan = 221,
        Vanuatu = 222,
        Venezuela = 223,
        Vietnam = 224,
        Yemen = 225,
        Zambia = 226,
        Zimbabwe = 227
    }
    public enum CommentType
    {
        [Description("For")]
        FOR = 1,
        [Description("Against")]
        AGAINST = 2,
    }
    public enum PagePosition
    {
        [Description("Left")]
        LEFT = 1,
        [Description("Right")]
        RIGHT = 2,
    }
    public enum Query_Type
    {
        [Description("Advertise")]
        ADVERTISE = 1,
        [Description("ContactUs")]
        CONTACTUS = 2,
        [Description("Idea")]
        IDEA = 3,
    }

    public enum IdeaAndTopic
    {
        [Description("Debate_Topic")]
        Debate_Topic = 1,
        [Description("Innovative_Idea")]
        Innovative_Idea = 2,
    }

    public enum RewardType
    {
        [Description("Topic")]
        TOPIC = 1,
        [Description("Idea")]
        IDEA = 2,
        [Description("Advertisement")]
        ADVERTISEMENT = 3,
        [Description("Add Memeber")]
        MEMBER = 4,
        [Description("Winner")]
        WINNER = 5,
    }

    public enum RewardPoints
    {
        [Description("Topic")]
        TOPIC = 10,
        [Description("Idea")]
        IDEA = 10,
        [Description("Advertisement")]
        ADVERTISEMENT = 10,
        [Description("In Member")]
        IN_MEMBER = 15,
        [Description("Other member")]
        OTHER_MEMBER = 30,
        [Description("Winner")]
        WINNER = 50,
    }

    public enum IsActive
    {
        [Description("True")]
        TRUE = 1,
        [Description("False")]
        FALSE = 0,
    }

}
