using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Exercise:Base
    {
        public string Description { get; set; }
        public Difficulty ExDifficulty { get; set; }
        public MuscleType ExMuscleType { get; set; }
        public SubMuscleType ExSubMuscleType { get; set; }
    }
}
