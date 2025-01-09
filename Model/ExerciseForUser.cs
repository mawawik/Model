using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExerciseForUser : Base
    {
        public User UserId { get; set; }
        public Exercise ExerciseId { get; set; }
        public WeekDays DayOfWeek { get; set; }

        public override string ToString()
        {
            return UserId.Id+" "+ExerciseId.Id+" "+DayOfWeek.WeekDay;
        }
    }
}
