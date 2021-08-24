using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Service
{
    public class Section: Entity
    {
        /*
        "name": "6A",
        "created": "2021-05-22T20:46:09.92",
        "exit_time": "2021-05-20T17:33:01.167",
        "state_id": 1,
        "teacher_id": 888888888
         */
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Exit_time { get; set; } = DateTime.Now;
        public int State_id { get; set; }
        public long Teacher_id { get; set; }

        public Section()
        {

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
