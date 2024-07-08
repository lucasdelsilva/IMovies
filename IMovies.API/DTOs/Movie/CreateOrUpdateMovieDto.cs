﻿namespace IMovies.API.DTOs.Movie
{
    public class CreateOrUpdateMovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public List<string> Gender { get; set; }
        public List<string> Actors { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
    }
}