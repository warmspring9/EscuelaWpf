using CsvHelper;
using EscuelaWPF.Service;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Core
{
    public class CSVHelper
    {
        public CSVHelper()
        {

        }

        public void ToCSV(List<AttendanceEntries> info, string id)
        {
            var records = info;
            string downloadPath = new KnownFolder(KnownFolderType.Downloads).Path;
            using (var writer = new StreamWriter(downloadPath + "\\" + id + ".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture, false))
            {
                csv.WriteRecords(records);
            }

        }
    }
}
