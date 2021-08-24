using System;

namespace EscuelaWPF.Service
{
    public class Attendance
    {
        public string Id { get; set; }

        public string description { get; set; } = "no description";

        public DateTime entrance_time { get; set; }

        public DateTime exit_time { get; set; }

        public int guardian_id { get; set; }
        public int student_id { get; set; }
        public int state_id { get; set; }


        public Attendance() { }

        public override string ToString()
        {
            String tiempo = exit_time.ToString("MMMM dd/yyyy");
            return student_id + " recogido por " + guardian_id + "a las " + tiempo;
        }
    }
}
