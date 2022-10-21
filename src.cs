using System.Collections.Generic;
using System.Linq;

namespace Movie_CRUD{

	public class MovieObject{
		public string movie_name {get; set;}
		public string genre {get; set;}
		public int trend_score {get; set;}
	}

	public class Movie{

		private List<MovieObject> masterListMovie = new List<MovieObject>();
		private Dictionary<string, List<MovieObject>> dicGenreWithMovieList = new Dictionary<string, List<MovieObject>>();

		public void CreateMovie(MovieObject movie){
			masterListMovie.Add(movie);

			List<MovieObject> pl = new List<MovieObject>();

			dicGenreWithMovieList.TryGetValue(movie.genre, out pl);
			if(pl != null && pl.Count > 0){
				dicGenreWithMovieList[movie.genre] =  masterListMovie.Where(a => a.genre == movie.genre).ToList();
			}
			else{
				dicGenreWithMovieList.Add(movie.genre, masterListMovie.Where(a => a.genre == movie.genre).ToList());
			}
		}

		public List<MovieObject> GetMovies(){
			return masterListMovie;
		}

		public string getMovieWithMaxTrendScoreByGenre(string genre){
			return dicGenreWithMovieList[genre].MaxBy(a => a.trend_score ).movie_name;
		}

		public void updateMovieTrendScore(string movieName,int score){
			var r = masterListMovie.Find(a => a.movie_name == movieName);
			r.trend_score = score;
		}
	}
}
