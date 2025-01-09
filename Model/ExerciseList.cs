using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExerciseList : List<Exercise>
    {
        public ExerciseList() { }
        public ExerciseList(IEnumerable<Exercise> list) : base(list) { }
        public ExerciseList(IEnumerable<Base> list) : base(list.Cast<Exercise>().ToList()) { }
    }
}
