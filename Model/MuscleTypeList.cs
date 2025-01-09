using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MuscleTypeList : List<MuscleType>
    {
        public MuscleTypeList() { }
        public MuscleTypeList(IEnumerable<MuscleType> list) : base(list) { }
        public MuscleTypeList(IEnumerable<Base> list) : base(list.Cast<MuscleType>().ToList()) { }
    }
}
