using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMovies.API.Domain.Models
{
    public class Movie
    {
        [DefaultValue("newid()")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public List<string> Gender { get; set; }
        public List<string> Actors { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
    }
}
