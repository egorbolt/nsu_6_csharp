using System;

namespace lab4_worker {
    class Program {
        static void Main(string[] args) {
            using (ApplicationContext db = new ApplicationContext()) {
                Worker worker1 = new Worker {FIO = "Boldyrev Egor Dmitrievich"};

                db.Workers.Add(worker1);
                db.SaveChanges();
                Console.WriteLine("saved");
            }
        }
    }

}