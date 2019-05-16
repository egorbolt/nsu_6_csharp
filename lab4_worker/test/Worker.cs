using System.Collections.Generic;

namespace test
{
    public class Worker
    {
        public int Id { get; set; }
        public string WorkerFIO { get; set; }
        //public int WorkerNumber { get; set; }
        public virtual ICollection<Project> WorkerProjects { get; set; }
    }
}