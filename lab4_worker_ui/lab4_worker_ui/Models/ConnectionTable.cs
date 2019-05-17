using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4_worker_ui.Models
{
    public class ConnectionTable
    {
        public int ConnectionTableID { get; set; }
        public int WorkerID { get; set; }
        public int ProjectID { get; set; }

        public Worker Worker { get; set; }
        public Project Project { get; set; }
    }
}
