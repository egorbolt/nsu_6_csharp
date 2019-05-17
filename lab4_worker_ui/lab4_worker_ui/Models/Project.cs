using System;
using System.Collections.Generic;

namespace lab4_worker_ui.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ProjectMoney { get; set; }

        public ICollection<ConnectionTable> ConnectionTables { get; set;  }
    }
}