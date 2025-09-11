using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_CodeFirst.Models;
using System.Data.Entity;

namespace MVC_CodeFirst.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db = new MovieContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.movie.ToList();
        }

        public Movie GetById(int id)
        {
            return db.movie.Find(id);
        }

        public void Create(Movie movie)
        {
            db.movie.Add(movie);
            db.SaveChanges();
        }

        public void Edit(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = db.movie.Find(id);
            if (movie != null)
            {
                db.movie.Remove(movie);
                db.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetAllMoviesByYear(int year)
        {
            return db.movie.Where(m => m.DateofRelease.Year == year).ToList();
        }

        public IEnumerable<Movie> GetMoviesByDirector(string directorName)
        {
            return db.movie.Where(m => m.DirectorName.ToLower() == directorName.ToLower()).ToList();
        }
    }
}
