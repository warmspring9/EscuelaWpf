using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Service
{
    public class Guardian: Entity
    {
        #region Public Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Phone_num { get; set; }
        public int State_id { get; set; }

        public string Image { get; set; }

        #endregion

        public Guardian()
        {

        }

        public override string ToString()
        {
            return Name + " " + Last_name;
        }
    }
}
