using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Worker.UI.DB
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ProjectMoney { get; set; }

        public ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}
