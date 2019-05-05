using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace lab4
{
    public class Functions
    {
        public void Add(string FIO, string Name, int Money)
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                var project = new Project() {ProjectName = Name, ProjectMoney = Money};
                List<Project> wpProjects = new List<Project>();
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
                try
                {
                    var worker = db.Workers.Include(e => e.WorkerProjects).First(e => id == e.Id);
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
                } catch (System.InvalidOperationException eIOE)
                {
                    Console.WriteLine("Error: no such worker with that id");
                }
            }
        }

        public void ListWorkers()
        {
            using (var db = new ApplicationContext())
            {
                var workers = db.Workers.ToList();
                foreach (Worker w in workers)
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
                try
                {
                    var worker = db.Workers.Include(e => e.WorkerProjects).First(e => id == e.Id);

                    if (worker == null)
                    {
                        Console.WriteLine("Can't find worker with such FIO");
                    }
                    else
                    {
                        foreach (var p in worker.WorkerProjects)
                        {
                            Console.WriteLine($"{p.Id}.{p.ProjectName} {p.ProjectMoney}");
                        }
                    }
                } catch (System.InvalidOperationException eIOE)
                {
                    Console.WriteLine("Error: no such worker with that id");
                }
            }
        }

        public void DeleteWorker(int id)
        {
            
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();

                try
                {
                    var worker = db.Workers.Include(e => e.WorkerProjects).First(e => id == e.Id);
                    
                    if (worker != null)
                    {
                        foreach (var p in worker.WorkerProjects)
                        {
                            db.Entry(p).State = EntityState.Deleted;
                        }

                        //удаляем объект
                        db.Workers.Remove(worker);
                        db.SaveChanges();
                    }

                }
                catch (System.InvalidOperationException eIOE)
                {
                    Console.WriteLine("Error: no such worker with that id");
                }

            }
        }

        public void ListWorkersTask()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                DbSet<Worker> workers = db.Workers;

                var query = from worker in workers
                    orderby worker.WorkerProjects.Sum(e => e.ProjectMoney) descending 
                    select new
                    {
                        FIO = worker.WorkerFIO,
                        TotalMoney = worker.WorkerProjects.Sum(e => e.ProjectMoney)
                    };

                foreach (var w in query)
                {
                    Console.WriteLine("FIO: {0}, total money: {1}", w.FIO, w.TotalMoney);
                }
            }
            
        }
    }
}