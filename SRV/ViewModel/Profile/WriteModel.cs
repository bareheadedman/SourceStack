using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel.Profile
{
    public class WriteModel
    {

        public string Icon { get; set; }

        public bool IsMale { get; set; }

        public int BirthdayYear { get; set; }

        public int BirthdayMonth { get; set; }

        public string Keyword { get; set; }

        public string SelfIntorduction { get; set; }

        //星座
        public enum Constellation
        {
            Aries,
            Taurus,
            Gemini,
            kingcrab,
            Leo,
            virgo,
            libra,
            Scorpio,
            sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }

    }
}
