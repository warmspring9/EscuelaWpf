using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Service
{
    public class Student : Entity
    {

        /*
            "id": 117500000,
            "name": "Juanito",
            "last_name": "Reyes C",
            "phone_num": "88680040",
            "expiration_date": "2021-05-20T17:33:01.167",
            "Document":"{{testPdf}}",
            "image":"{{testImg}}",
            "state_id": 1,
            "section_id": 1,
            "guardian_id": 117500795
         */

        public long Id { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Phone_num { get; set; }
        public DateTime Expiration_date { get; set; }
        public string Document { get; set; }
        public string Image { get; set; }
        public int State_id { get; set; }
        public int Section_id { get; set; }
        public long Guardian_id { get; set; }
        public Student()
        {

        }
    }
}
