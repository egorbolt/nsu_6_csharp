namespace lab7_auth
{
    class Program
    {
        static void Main(string[] args)
        {   
            using (var logic = new Logic())
            {
                logic.Execute();
            }
        }
    }
}
