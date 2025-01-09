using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:Base
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender UserGender { get; set; }

        public override string ToString()
        {
            return (Password + " " + UserName + " " + UserGender.GenderName + " " + Email + " " + BirthDate);

        }

    }
}
