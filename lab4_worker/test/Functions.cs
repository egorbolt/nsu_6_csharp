using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace test
{
    public class Functions
    {
        public void Add(string FIO, string Name, int Money)
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                var project = new Project() {ProjectName = Name, ProjectMoney = Money};
                var wpProjects = new List<Project>();
                wpProjects.Add(project);
                var worker = new Worker
                {
                    WorkerFIO = FIO,
                    WorkerProjects = wpProjects
                };
 
                db.Projects.Add(project);
                db.Workers.Add(worker);
                db.SaveChanges();
            }
        }

        public void AddProject(int id, string FIO, string Name, int Money)
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                var worker = db.Workers.Include(e => e.WorkerProjects).FirstOrDefault(e => id == e.Id);
                if (worker == null)
                {
                    Console.WriteLine("Can't find worker with such FIO, creating entry for a new worker");
                    this.Add(FIO, Name, Money);
                }
                else
                {
                    var project = new Project() {ProjectName = Name, ProjectMoney = Money};
                    worker.WorkerProjects.Add(project);
                    db.Projects.Add(project);
                    db.Workers.Update(worker);
                    db.SaveChanges();
                }
            }
        }

        public void ListWorkers()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                var workers = db.Workers.ToList();
                foreach (var w in workers)
                {
                    Console.WriteLine($"{w.Id}.{w.WorkerFIO}");
                }
            }
        }

        public void ListWorkerProjects(int id)
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                
                var worker = db.Workers.Include(e => e.WorkerProjects).FirstOrDefault(e => id == e.Id);

                if (worker == null)
                {
                    Console.WriteLine("Can't find worker with such id");
                }
                else
                {
                    foreach (var p in worker.WorkerProjects)
                    {
                        Console.WriteLine($"{p.Id}.{p.ProjectName} {p.ProjectMoney}");
                    }
                }
            }
        }

        public void DeleteWorker(int id)
        {
            
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();

                var worker = db.Workers.Include(e => e.WorkerProjects).First(e => id == e.Id);
                
                if (worker != null)
                {
                    foreach (var p in worker.WorkerProjects)
                    {
                        db.Entry(p).State = EntityState.Deleted;
                    }

                    db.Workers.Remove(worker);
                    db.SaveChanges();
                }
            }
        }

        public void ListWorkersTask()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                DbSet<Worker> workers = db.Workers;

//                var query = from worker in workers
//                    orderby worker.WorkerProjects.Sum(e => e.ProjectMoney) descending 
//                    select new
//                    {
//                        FIO = worker.WorkerFIO,
//                        TotalMoney = worker.WorkerProjects.Sum(e => e.ProjectMoney)
//                    };

                var query = workers
                    .Select(worker => new
                    {
                        FIO = worker.WorkerFIO,
                        TotalMoney = worker.WorkerProjects.Sum(e => e.ProjectMoney)
                    })
                    .OrderByDescending(worker => worker.TotalMoney);
                
                foreach (var w in query)
                {
                    Console.WriteLine("FIO: {0}, total money: {1}", w.FIO, w.TotalMoney);
                }
            }
            
        }

        public void ChangeWorkerString(int id, string NewString)
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                var worker = db.Workers.Include(e => e.WorkerProjects).FirstOrDefault(e => id == e.Id);

                if (worker != null)
                {
                    Console.WriteLine("Previous worker's string was {0}", worker.WorkerString);
                    worker.WorkerString = NewString;
                    db.Workers.Update(worker);
                    db.SaveChanges();
                    //worker = db.Workers.Include(e => e.WorkerProjects).FirstOrDefault(e => id == e.Id);
                    Console.WriteLine("New worker's string: {0}", worker.WorkerString);
                }
            }
        }
    }
}