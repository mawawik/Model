using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WeekDaysList : List<WeekDays>
    {
        public WeekDaysList() { }
        public WeekDaysList(IEnumerable<WeekDays> list) : base(list) { }
        public WeekDaysList(IEnumerable<Base> list) : base(list.Cast<WeekDays>().ToList()) { }
    }
}
