using MovieDatabase.Domain.Models;
using System.Collections.Generic;

namespace MovieDatabase.Domain.Interfaces
{
    public interface IGenreService
    {
        ICollection<Genre> GetAll();
    }
}
