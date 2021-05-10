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
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Movie Search");
                Console.WriteLine("3. Add Movie");
                Console.WriteLine("4. Update Movie");
                Console.WriteLine("5. Delete Movie");
                Console.WriteLine("6. Add User");
                Console.WriteLine("7. List Users");
                Console.WriteLine("8. Quit Application");
                String choice = Console.ReadLine();
                MovieRepo m = new MovieRepo();
                if(choice == "1"){
                    Console.WriteLine();
                    m.ListMedia(db);
                }
                else if(choice == "2"){
                    Console.WriteLine();
                    m.SearchMedia(db);
                }
                else if(choice == "3"){
                    Console.WriteLine();
                    m.AddMedia(db);
                }
                else if(choice == "4"){
                    Console.WriteLine();
                    m.UpdateMedia(db);
                }
                else if(choice == "5"){
                    Console.WriteLine();
                    m.DeleteMedia(db);
                }
                else if(choice == "6"){
                    Console.WriteLine();
                    m.AddUser(db);
                }
                else if(choice == "7"){
                    Console.WriteLine();
                    m.ListUsers(db);
                }
                else if(choice == "8"){
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