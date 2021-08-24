using System;

namespace EscuelaWPF.Service
{
    public class Authorization
    {
        /* 
            "state_id": 1,
            "guardian_id": 117500761,
            "student_id": 117500000,
            "start_time": "2021-05-29T22:19:31.173",
            "end_time": "2021-05-29T22:19:31.173"
         */

        public string Guardian_id { get; set; }

        public string Student_id { get; set; }

        public DateTime Start_time { get; set; }

        public DateTime End_time { get; set; }

        public int State_id { get; set; }

        public Authorization() { }

    }
}
