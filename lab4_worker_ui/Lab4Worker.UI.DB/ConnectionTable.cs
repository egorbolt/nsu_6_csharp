using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Worker.UI.DB
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
