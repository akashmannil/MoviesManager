using Microsoft.AspNetCore.Mvc;
using MoviesManager.Models;

namespace MoviesManager.Controllers
{
    public class MoviesController : Controller
    {
        public static int movieIdCount = 10;
        public static List<Movie> movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Drishyam", Director = "Jeethu Joseph", Genre = "Thriller", Year = 2013, Rating = 9.0, Cast = "Mohanlal, Meena" },
            new Movie { Id = 2, Title = "Premam", Director = "Alphonse Puthren", Genre = "Romance", Year = 2015, Rating = 8.5, Cast = "Nivin Pauly, Sai Pallavi" },
            new Movie { Id = 3, Title = "Kumbalangi Nights", Director = "Madhu C. Narayanan", Genre = "Drama", Year = 2019, Rating = 8.8, Cast = "Fahadh Faasil, Shane Nigam" },
            new Movie { Id = 4, Title = "Bangalore Days", Director = "Anjali Menon", Genre = "Comedy/Drama", Year = 2014, Rating = 8.6, Cast = "Dulquer Salmaan, Nivin Pauly, Nazriya Nazim" },
            new Movie { Id = 5, Title = "Eeda", Director = "B. Ajithkumar", Genre = "Romantic Drama", Year = 2018, Rating = 7.8, Cast = "Shane Nigam, Nimisha Sajayan" },
            new Movie { Id = 6, Title = "Charlie", Director = "Martin Prakkat", Genre = "Romantic Drama", Year = 2015, Rating = 8.3, Cast = "Dulquer Salmaan, Parvathy Thiruvothu" },
            new Movie { Id = 7, Title = "Uyare", Director = "Manu Ashokan", Genre = "Drama", Year = 2019, Rating = 8.2, Cast = "Parvathy Thiruvothu, Asif Ali, Tovino Thomas" },
            new Movie { Id = 8, Title = "Maheshinte Prathikaaram", Director = "Dileesh Pothan", Genre = "Comedy/Drama", Year = 2016, Rating = 8.7, Cast = "Fahadh Faasil, Aparna Balamurali" },
            new Movie { Id = 9, Title = "Take Off", Director = "Mahesh Narayanan", Genre = "Thriller/Drama", Year = 2017, Rating = 8.1, Cast = "Parvathy Thiruvothu, Kunchacko Boban" },
            new Movie { Id = 10, Title = "Angamaly Diaries", Director = "Lijo Jose Pellissery", Genre = "Action/Drama", Year = 2017, Rating = 8.0, Cast = "Antony Varghese, Reshma Rajan" }
        };

        public IActionResult Index()
        {
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = ++movieIdCount;
                movies.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                ViewData["Title"] = $"Edit Details of {movie.Title}";
                return View(movie);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var index = movies.FindIndex(m => m.Id == movie.Id);
                if (index >= 0)
                {
                    movies[index] = movie;
                }
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public IActionResult Details(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return View(movie);
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return View(movie);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConf(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                // Not reducing Id count as we keep that as a reference for ids encountered
                movies.Remove(movie);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}