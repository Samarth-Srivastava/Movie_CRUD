//driver code
using System;
using System.IO;

namespace Movie_CRUD{
	public class Program{
		public static void Main(string[] args){
			Movie s = new Movie();

			s.CreateMovie(new MovieObject{ genre = "a",movie_name = "abc",trend_score = 1});
			s.CreateMovie(new MovieObject{ genre = "b",movie_name = "bcd",trend_score = 2});
			s.CreateMovie(new MovieObject{ genre = "b",movie_name = "cde",trend_score = 3});
			s.CreateMovie(new MovieObject{ genre = "a",movie_name = "def",trend_score = 4});
			s.CreateMovie(new MovieObject{ genre = "a",movie_name = "efg",trend_score = 5});

			var rA = s.getMovieWithMaxTrendScoreByGenre("a");
			var rB = s.getMovieWithMaxTrendScoreByGenre("b");
			
			s.updateMovieTrendScore("efg", 1);

		}
	}
}
