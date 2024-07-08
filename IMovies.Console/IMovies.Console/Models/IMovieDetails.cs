using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMovies.Console.Models
{
    public class IMovieDetails
    {
        [DefaultValue("newid()")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid GuidId { get; set; }
        public bool Adulto { get; set; }
        public string BackGroundPath { get; set; }
        public string PosterPath { get; set; }
        public List<Genres> Genres { get; set; }
        public string IMovieDb { get; set; }
        public string OriginCountry { get; set; }
        public string OriginLanguage { get; set; }
        public string OriginTitle { get; set; }
        public string DescriptionMovie { get; set; }
        public List<Companies> Companies { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Languages> Languages { get; set; }
        public string Title { get; set; }
        public string TagLine { get; set; }
        public double VoteAverage { get; set; }
        public double VoteCount { get; set; }
    }

    public class Genres
    {
        public int value { get; set; }
        public string Description { get; set; }
    }

    public class Languages
    {
        public string NameLanguage { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
    }

    public class Companies
    {
        public int value { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}