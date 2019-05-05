using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            String line = null;
            Functions functions = new Functions();
            
            Console.WriteLine("Available commands: add, add_project, list_workers, list_worker_projects, delete_worker, task, exit");
            
            do
            {
                line = Console.ReadLine();

                if (line.Equals("add"))
                {
                    Console.Write("FIO: ");
                    String FIO = Console.ReadLine();
                    Console.Write("Project's name: ");
                    String Name = Console.ReadLine();
                    Console.Write("Worker's salary: ");
                    int Money = Int32.Parse(Console.ReadLine());

                    Project project = new Project {ProjectName = Name, ProjectMoney = Money};
                    List<Project> projectList = new List<Project>();
                    projectList.Add(project);
                    Worker worker = new Worker {WorkerFIO = FIO, WorkerProjects = projectList};

                    functions.Add(FIO, Name, Money);
                }

                if (line.Equals("list_workers"))
                {
                    functions.ListWorkers();
                }

                if (line.Equals("add_project"))
                {
                    Console.Write("Workers's id: ");
                    int id = Int32.Parse(Console.ReadLine());
                    Console.Write("FIO: ");
                    String FIO = Console.ReadLine();
                    Console.Write("Project's name: ");
                    String Name = Console.ReadLine();
                    Console.Write("Worker's salary: ");
                    int Money = Int32.Parse(Console.ReadLine());
                    
                    functions.AddProject(id, FIO, Name, Money);
                }

                if (line.Equals("list_worker_projects"))
                {
                    Console.Write("Worker's ID: ");
                    int id = Int32.Parse(Console.ReadLine());
                    
                    functions.ListWorkerProjects(id);
                }

                if (line.Equals("delete_worker"))
                {
                    Console.Write("Worker's ID: ");
                    int id = Int32.Parse(Console.ReadLine());
                    
                    functions.DeleteWorker(id);
                }

                if (line.Equals("task"))
                {
                    functions.ListWorkersTask();
                }

            } while (!line.Equals("exit"));

        }        
    }
}    
