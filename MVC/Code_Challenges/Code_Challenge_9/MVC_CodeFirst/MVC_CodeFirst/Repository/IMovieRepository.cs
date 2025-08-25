using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_CodeFirst.Models;

namespace MVC_CodeFirst.Repository
{
    interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Create(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetAllMoviesByYear(int year);
        IEnumerable<Movie> GetMoviesByDirector(string directorName);
    }
}
