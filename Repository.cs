using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Models;
using LibraryConsole;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository{
    public interface IRepository
    {
        void SearchMedia(BloggingContext db);
        void AddMedia(BloggingContext db);
        void UpdateMedia(BloggingContext db);
        void DeleteMedia(BloggingContext db);
    }
    public class MovieRepo : IRepository
    {
        public void SearchMedia(BloggingContext db)
        {
            // Searches database for movies
            // Done
            var movies = db.Movies.OrderBy(m => m.title);
            if(movies.Count()>0){
                Console.WriteLine("Which movie would you like to search for?");
                String selection = Console.ReadLine();
                selection = selection.ToLower();
                int i = 0;
                foreach(var movie in movies){
                    if(movie.title.ToLower()==selection){
                        Console.WriteLine("Title: " + movie.title + " Genres: " + movie.genres);
                        i++;
                    }
                }
                if(i==0){
                    Console.WriteLine("Movie not in database");
                }
            }
            else{
                Console.WriteLine("No movies in database");
            }
            Console.WriteLine();
        }
        public void AddMedia(BloggingContext db)
        {
            // Adds movie to database
            // Done
            Console.WriteLine("Enter Movie Info");
            var movies = db.Movies.OrderBy(m => m.title);
            Movie movie = new Movie();
            int x = 1;
            while(x==1){
                Console.Write("Title: ");
                movie.title = Console.ReadLine();
                x=0;
                foreach(var m in movies){
                    if(m.title == movie.title){
                        x=1;
                    }
                }
                if(x==1){
                    Console.WriteLine("Entry already in database");
                }
            }
            x=1;
            Console.Write("Genre: ");
            String genreString = Console.ReadLine();
            Console.WriteLine("Add another genre? 1=yes 2=no");
            x = int.Parse(Console.ReadLine());
            while(x == 1){
                Console.Write("Genre: ");
                String genre = Console.ReadLine();
                genreString = genreString + ", " + genre;
                Console.WriteLine("Add another genre? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
            movie.genres = genreString;
            db.Movies.Add(movie);
            db.SaveChanges();
            Console.WriteLine("Movie Added");
            Console.WriteLine();
        }
        public void UpdateMedia(BloggingContext db)
        {
            var movies = db.Movies.OrderBy(m => m.id).ToList();
            int i = 1;
            if(movies.Count()>0){
                int selection;
                
                Console.WriteLine("Which movie would you like to update?");
                foreach(var movie in movies){
                    Console.WriteLine(movie.id + ") " + movie.title);
                }
                selection = Int32.Parse(Console.ReadLine());
                Console.WriteLine("1) Change title");
                Console.WriteLine("2) Change genres");
                Console.WriteLine("3) Change title and genres");
                int branchSelection = Int32.Parse(Console.ReadLine());
                if(branchSelection<=3&&branchSelection>=1){
                    foreach(var movie in movies){
                        if(selection == movie.id){
                            if(branchSelection == 1){
                                Console.Write("Title: ");
                                movie.title = Console.ReadLine();
                            }
                            else if(branchSelection == 2){
                                int x=1;
                                Console.Write("Genre: ");
                                String genreString = Console.ReadLine();
                                Console.WriteLine("Add another genre? 1=yes 2=no");
                                x = int.Parse(Console.ReadLine());
                                while(x == 1){
                                    Console.Write("Genre: ");
                                    String genre = Console.ReadLine();
                                    genreString = genreString + ", " + genre;
                                    Console.WriteLine("Add another genre? 1=yes 2=no");
                                    x = int.Parse(Console.ReadLine());
                                }
                                movie.genres = genreString;
                            }
                            else if(branchSelection == 3){
                                Console.Write("Title: ");
                                movie.title = Console.ReadLine();
                                int x=1;
                                Console.Write("Genre: ");
                                String genreString = Console.ReadLine();
                                Console.WriteLine("Add another genre? 1=yes 2=no");
                                x = int.Parse(Console.ReadLine());
                                while(x == 1){
                                    Console.Write("Genre: ");
                                    String genre = Console.ReadLine();
                                    genreString = genreString + ", " + genre;
                                    Console.WriteLine("Add another genre? 1=yes 2=no");
                                    x = int.Parse(Console.ReadLine());
                                }
                                movie.genres = genreString;
                            }
                            db.Update(movie);
                            db.SaveChanges();
                            i++;
                        }
                    }
                }
                else{
                    Console.WriteLine("Unrecognized Command");
                }
                
            }
            else{
                Console.WriteLine("No movies in database");
            }
            Console.WriteLine();
        }
        public void DeleteMedia(BloggingContext db)
        {
            
            
            var movies = db.Movies.OrderBy(m => m.id).ToList();
            if(movies.Count()>0){
                Console.WriteLine("Which movie would you like to delete?");
                foreach(var movie in movies){
                    Console.WriteLine(movie.id + ") " + movie.title);
                }
                int selection = Int32.Parse(Console.ReadLine());
                foreach(var movie in movies){
                    if(selection == movie.id){
                        db.Entry(movie).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            else{
                Console.WriteLine("No movies in database");
            }
            Console.WriteLine();
        }   
        public void ListMedia(BloggingContext db)
        {
            var movies = db.Movies.OrderBy(m => m.id).ToList();
            if(movies.Count()>0){
                foreach(var movie in movies){
                    Console.WriteLine(movie.id + ") " + movie.title);
                }
            }
            else{
                Console.WriteLine("No movies in database");
            }
            Console.WriteLine();
        }
        public void AddUser(BloggingContext db)
        {
            Console.WriteLine("Enter User Info");
            User user = new User();
            Console.Write("Username: ");
            user.name = Console.ReadLine();
            Console.Write("Occupation: ");
            user.occupation = Console.ReadLine();
            db.Users.Add(user);
            db.SaveChanges();
            Console.WriteLine("User Added");
            Console.WriteLine("Username: " + user.name);
            Console.WriteLine("Occupation: " + user.occupation);
            Console.WriteLine();
        }
        public void ListUsers(BloggingContext db)
        {
            var users = db.Users.OrderBy(u => u.id).ToList();
            if(users.Count()>0){
                foreach(var user in users){
                    Console.WriteLine(user.id + ") " + user.name);
                }
            }
            else{
                Console.WriteLine("No users in database");
            }
            Console.WriteLine();
        }
    } 
}