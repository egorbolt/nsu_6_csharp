using System;
using System.Collections.Generic;

namespace lab4_worker_ui.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public string WorkerFIO { get; set; }

        public ICollection<ConnectionTable> ConnectionTables { get; set; }

    }
}