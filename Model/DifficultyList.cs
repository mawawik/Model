using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DifficultyList : List<Difficulty>
    {
        public DifficultyList() { }
        public DifficultyList(IEnumerable<Difficulty> list) : base(list) { }
        public DifficultyList(IEnumerable<Base> list) : base(list.Cast<Difficulty>().ToList()) { }
    }
}
