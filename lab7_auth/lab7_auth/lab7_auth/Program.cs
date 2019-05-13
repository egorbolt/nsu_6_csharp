namespace lab7_auth
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            logic.Execute();
            logic.Dispose();
        }
    }
}
