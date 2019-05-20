using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Worker.UI.DB
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public string WorkerFIO { get; set; }

        public ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}
