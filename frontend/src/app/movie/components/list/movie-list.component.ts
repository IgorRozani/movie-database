import { Component, OnInit } from '@angular/core';
import { MovieDatabaseService } from 'src/app/movie/services/movie-database.service';
import { MovieListItem } from '../../models/movie-list-item';
import { MovieDetails } from '../../models/movie-details';

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  private currentPage: number = 1;
  private movies: MovieListItem[];
  private selectedMovie: MovieDetails;

  constructor(private movieDatabaseService: MovieDatabaseService) {
  }

  ngOnInit() {
    this.movies = [];
    this.getMovies();
  }

  getMovies(page: number = 1) {
    this.movieDatabaseService.getMovies(page).subscribe(data => {
      data.forEach(d => this.movies.push(d))
    })
  }

  onScroll() {
    this.currentPage++
    this.getMovies(this.currentPage)
  }

  openDetails(id: number) {
    console.log(id)
    this.movieDatabaseService.getMovieDetail(id).subscribe(data => {
      console.log(data)
      this.selectedMovie = data;
    });

  }
}
