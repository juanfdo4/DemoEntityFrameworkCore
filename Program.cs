using System;
using System.Collections;

namespace Movies
{
    class Program
    {
        static void Main(string[] args) => InicializarMenu();

        private static void InicializarMenu()
        {
            System.Console.WriteLine("Ingrese una opcion:");
            System.Console.WriteLine("1. Categorias");
            System.Console.WriteLine("2. Movies");
            System.Console.WriteLine("3. Ver Movies");
            System.Console.WriteLine("4. Ver Categorias");
            System.Console.WriteLine("5. Eliminar Movie");
            System.Console.WriteLine("6. Eliminar Categoria");
            var opcion = Console.ReadLine();
            if(opcion == "1"){
                IngresarCategorias();
            }
             else if(opcion == "2"){
               IngresarMovies();
            }
            else if(opcion == "3"){
               VerMovies(true);
            }
            else if(opcion == "4"){
               VerCategorias(true);
            }
            else if(opcion == "5"){
               EliminarMovie();
            }
            else if(opcion == "6"){
               EliminarCategoria();
            }
        }

        private static void EliminarMovie()
        {
            VerMovies();
            System.Console.WriteLine("Ingresar Movie a eliminar:");
            var id = int.Parse(Console.ReadLine());
            var db = new MoviesDbContext();
            var movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            db.Dispose();
        }

        private static void EliminarCategoria()
        {
            VerCategorias();
            System.Console.WriteLine("Ingresar categoria a eliminar:");
            var id = int.Parse(Console.ReadLine());
            var db = new MoviesDbContext();
            var categoria = db.Categories.Find(id);
            db.Categories.Remove(categoria);
            db.SaveChanges();
            db.Dispose();
        }

        private static void VerMovies(bool MostrarMenu = false)
        {
            var db = new MoviesDbContext();
             
            System.Console.WriteLine("Movies disponibles:");
            var listMovies = db.Movies;
            foreach (var movie in listMovies)
            {
                System.Console.WriteLine(string.Format("{0}: {1} ", movie.Id, movie.Name));
            }
            System.Console.WriteLine("..............................");
            db.Dispose();
            if (MostrarMenu) InicializarMenu();

        }

        private static void VerCategorias(bool MostrarMenu = false)
        {
            var db = new MoviesDbContext();
             
            System.Console.WriteLine("Categorias disponibles:");
            var listCategorias = db.Categories;
            foreach (var categoria in listCategorias)
            {
                System.Console.WriteLine(string.Format("{0}: {1}", categoria.Id, categoria.Name));
            }
            System.Console.WriteLine("..............................");
            db.Dispose();
            if (MostrarMenu) InicializarMenu();

        }

        private static void IngresarMovies()
        {
            var db = new MoviesDbContext();
           VerCategorias();
            var movie = new Movie();
            
            System.Console.WriteLine("Ingrese nombre de la movie");
            movie.Name = Console.ReadLine();

            System.Console.WriteLine("Ingrese año de la movie");
            movie.Year =int.Parse(Console.ReadLine());

            System.Console.WriteLine("Ingrese id de la categoria");
            var idCategoria =int.Parse(Console.ReadLine());
            var category = db.Categories.Find(idCategoria);

            movie.IdCategory = idCategoria;
            movie.Category = category;

            db.Movies.Add(movie);
            db.SaveChanges();
            System.Console.WriteLine("Movie almacenada correctamente");

            System.Console.ReadKey();   
            db.Dispose();
            InicializarMenu();

        }

        private static void IngresarCategorias()
        {
            var db = new MoviesDbContext();
                for (int i = 0; i < 3; i++)
                {
                    System.Console.WriteLine("Ingrese categoria");
                    var categoria = Console.ReadLine();

                    var category = new Category();
                    category.Name = categoria;
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
                db.Dispose();
                System.Console.WriteLine("Categorias almacenadas correctamente");
                System.Console.ReadKey();   
                InicializarMenu();
        }
    }
}
