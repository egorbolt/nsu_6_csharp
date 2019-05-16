using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = null;
            var functions = new Functions();

            Console.WriteLine("Available commands: add, add_project, list_workers, list_worker_projects, delete_worker, task, exit, ws");

            do
            {
                line = Console.ReadLine();

                if (line.Equals("add"))
                {
                    Console.Write("FIO: ");
                    var fio = Console.ReadLine();
                    Console.Write("Project's name: ");
                    var name = Console.ReadLine();
                    Console.Write("Worker's salary: ");
                    var money = int.Parse(Console.ReadLine());

                    var project = new Project { ProjectName = name, ProjectMoney = money };
                    List<Project> projectList = new List<Project>();
                    projectList.Add(project);
                    var worker = new Worker { WorkerFIO = fio, WorkerProjects = projectList };

                    functions.Add(fio, name, money);
                }

                if (line.Equals("list_workers"))
                {
                    functions.ListWorkers();
                }

                if (line.Equals("add_project"))
                {
                    Console.Write("Worker's id: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("FIO: ");
                    var fio = Console.ReadLine();
                    Console.Write("Project's name: ");
                    var name = Console.ReadLine();
                    Console.Write("Worker's salary: ");
                    var money = int.Parse(Console.ReadLine());

                    functions.AddProject(id, fio, name, money);
                }

                if (line.Equals("list_worker_projects"))
                {
                    Console.Write("Worker's ID: ");
                    if (int.TryParse(Console.ReadLine(), out var id))
                    {
                        functions.ListWorkerProjects(id);
                    }

                }

                if (line.Equals("delete_worker"))
                {
                    Console.Write("Worker's ID: ");
                    var id = int.Parse(Console.ReadLine());

                    functions.DeleteWorker(id);
                }

                if (line.Equals("task"))
                {
                    functions.ListWorkersTask();
                }

                if (line.Equals("ws"))
                {
                    Console.Write("Worker's ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New worker's string: ");
                    var str = Console.ReadLine();

                    functions.ChangeWorkerString(id, str);
                }

            } while (!line.Equals("exit"));

        }
    }
}
