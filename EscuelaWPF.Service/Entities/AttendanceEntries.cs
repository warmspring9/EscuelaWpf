using System;

namespace EscuelaWPF.Service
{
    public class AttendanceEntries
    {
        public string Descripcion { get; set; } = "Sin descripcion";

        public DateTime Hora_Entrada { get; set; }

        public DateTime Hora_Salida { get; set; }

        public String Nombre_Guardian { get; set; }
        public String Nombre_Estudiante { get; set; }


        public AttendanceEntries() { }
    }
}
