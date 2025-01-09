using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin:User
    {
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
