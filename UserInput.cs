using System;
using System.IO;
using Repository;
using Models;
using System.Collections.Generic;
using LibraryConsole;


namespace UserInput
{
    public class MainMenu
    {
        public void Menu()
        {
            var db = new BloggingContext();
            int x = 1;
            while(x == 1)
            {
                Console.WriteLine("Select Command");
                Console.WriteLine("1. Movie Search");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Update Movie");
                Console.WriteLine("4. Delete Movie");
                Console.WriteLine("5. Quit Application");
                String choice = Console.ReadLine();
                MovieRepo m = new MovieRepo();
                if(choice == "1"){
                    Console.WriteLine();
                    m.SearchMedia(db);
                }
                else if(choice == "2"){
                    Console.WriteLine();
                    m.AddMedia(db);
                }
                else if(choice == "3"){
                    Console.WriteLine();
                    m.UpdateMedia(db);
                }
                else if(choice == "4"){
                    Console.WriteLine();
                    m.DeleteMedia(db);
                }
                else if(choice == "5"){
                    x = 0;
                }
                else{
                    Console.WriteLine("Unrecognized Command");
                    Console.WriteLine();
                }
            }
        }
    }
}