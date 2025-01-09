using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExerciseForUserList : List<ExerciseForUser>
    {
        public ExerciseForUserList() { }
        public ExerciseForUserList(IEnumerable<ExerciseForUser> list) : base(list) { }
        public ExerciseForUserList(IEnumerable<Base> list) : base(list.Cast<ExerciseForUser>().ToList()) { }
    }
}
