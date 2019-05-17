using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab4_worker_ui.Models;

namespace lab4_worker_ui.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Workers.Any())
            {
                return;
            }

            var workers = new Worker[]
            {
                new Worker{WorkerFIO = "Ivanov Ivan Ivanovich"},
                new Worker{WorkerFIO = "Petrov Petr Petrovich"}
            };

            foreach (Worker w in workers)
            {
                context.Workers.Add(w);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
                new Project{ProjectID = 1, ProjectName = "Project1", ProjectMoney = 1000},
                new Project{ProjectID = 2, ProjectName = "Project2", ProjectMoney = 2000},
                new Project{ProjectID = 3, ProjectName = "Project3", ProjectMoney = 3000},
                new Project{ProjectID = 4, ProjectName = "Project4", ProjectMoney = 4000},
                new Project{ProjectID = 5, ProjectName = "Project5", ProjectMoney = 5000}
            };

            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();

            var connections = new ConnectionTable[]
            {
                new ConnectionTable{WorkerID = 1, ProjectID = 1},
                new ConnectionTable{WorkerID = 1, ProjectID = 2},
                new ConnectionTable{WorkerID = 1, ProjectID = 3},
                new ConnectionTable{WorkerID = 2, ProjectID = 4},
                new ConnectionTable{WorkerID = 2, ProjectID = 5},
            };

            foreach (ConnectionTable ct in connections)
            {
                context.ConnectionTables.Add(ct);
            }
            context.SaveChanges();
        }
    }
}
