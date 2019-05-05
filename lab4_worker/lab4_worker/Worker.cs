using System.Collections.Generic;

namespace lab4
{
    public class Worker
    {
        public int Id { get; set; }
        public string WorkerFIO { get; set; }
        public virtual ICollection<Project> WorkerProjects { get; set; }
    }
}