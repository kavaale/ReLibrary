using System;
using Repository;
using UserInput;

namespace HomeworkRefactor
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Menu();
        }
    }
}
