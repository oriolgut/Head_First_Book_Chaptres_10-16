using System;

namespace RobustGuy
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CreateGuy();
        }

        public void CreateGuy()
        {
            Console.Write("Enter birthday: ");
            string birthday = Console.ReadLine();
            Console.Write("Enter height in cm: ");
            string height = Console.ReadLine();
            RobustGuy guy = new RobustGuy(birthday, height);
            Console.WriteLine(guy.ToString());
            Console.Write("want to restart? (y/n): ");
            string answer = Console.ReadLine();
            if (answer.Equals("y"))
            {
                CreateGuy();
            }
            else
            {
                return;
            }
        }
    }
}
