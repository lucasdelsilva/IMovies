using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMovies.Console.Models
{
    public class IMovie
    {
        [DefaultValue("newid()")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool Adulto { get; set; }
        public string BackGroundPath { get; set; }
        public string PosterPath { get; set; }
        public List<int> Genres { get; set; }
        //Id
        public int MovieIdentification { get; set; }
        public string OriginLanguage { get; set; }
        public string OriginTitle { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public double VoteCount { get; set; }
    }
}