using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Shared
{
    public class Rang
    {
        public int RangID { get; set; }
        public string RangName { get; set; }

        public static Rang getRang(int rangId)
        {
            switch (rangId)
            {
                case 1: return new Rang() {RangID = rangId, RangName = "Admin" };
                case 2: return new Rang() { RangID = rangId, RangName = "Doktor" };
                case 3: return new Rang() { RangID = rangId, RangName = "Pacjent" };
                    default: return null;
            }
        }
    }
}
