using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new Tester1();
            var test2 = new Tester2();
            var test3 = new Tester3();

            var classApp = new ClassApp(test1);
            var employess = classApp.GetEmployess();

            for (int i = 0; i < employess.Length; i++)
            {
                Console.WriteLine(employess[i]);
            }

            classApp = new ClassApp(test2);
            employess = classApp.GetEmployess();

            for (int i = 0; i < employess.Length; i++)
            {
                Console.WriteLine(employess[i]);
            }

            classApp = new ClassApp(test3);
            employess = classApp.GetEmployess();

            for (int i = 0; i < employess.Length; i++)
            {
                Console.WriteLine(employess[i]);
            }

            Console.ReadKey();
        }
    }

    public class ClassApp
    {
        private ITester test1;

        public ClassApp(ITester test1)
        {
            this.test1 = test1;
        }

        internal string[] GetEmployess()
        {
            return test1.GetEmployees();
        }
    }

    public interface ITester
    {
        public string[] GetEmployees();
    }

    public class Tester1 : ITester
    {
        public string[] GetEmployees()
        {
            return new string[]
            {
                "Testers 1"
            };
        }
    }

    public class Tester2 : ITester
    {
        public string[] GetEmployees()
        {
            return new string[]
            {
                "Testers 2"
            };
        }
    }

    public class Tester3 : ITester
    {
        public string[] GetEmployees()
        {
            return new string[]
            {
                "Testers 3"
            };
        }
    }
}
