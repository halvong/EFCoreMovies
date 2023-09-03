using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public HashSet<Movie> Movies { get; set; }

    }
}
