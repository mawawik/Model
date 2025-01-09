using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SubMuscleTypeList : List<SubMuscleType>
    {
        public SubMuscleTypeList() { }
        public SubMuscleTypeList(IEnumerable<SubMuscleType> list) : base(list) { }
        public SubMuscleTypeList(IEnumerable<Base> list) : base(list.Cast<SubMuscleType>().ToList()) { }
    }
}
