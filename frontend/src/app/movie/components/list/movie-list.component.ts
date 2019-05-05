import { Component, OnInit } from '@angular/core';
import { MovieDatabaseService } from 'src/app/movie/services/movie-database.service';
import { MovieListItem } from '../../models/movie-list-item';
import { MovieDetails } from '../../models/movie-details';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  private currentPage: number = 1;
  private movies: MovieListItem[];
  selectedMovie: MovieDetails;
  private movieName:string;

  constructor(private movieDatabaseService: MovieDatabaseService, public ngxSmartModalService: NgxSmartModalService) {
  }

  ngOnInit() {
    this.movies = [];
    this.getMovies();
  }

  getMovies(page: number = 1, movieName:string = null) {
    this.movieDatabaseService.getMovies(page, undefined, movieName).subscribe(data => {
      data.forEach(d => this.movies.push(d))
    })
  }

  onScroll() {
    this.currentPage++
    this.getMovies(this.currentPage, this.movieName)
  }

  openDetails(id: number) {
    this.movieDatabaseService.getMovieDetail(id).subscribe(data => {
      this.selectedMovie = data;
      this.ngxSmartModalService.getModal('movieDetailsModal').open()
    });

  }

  searchMovie(movieName: string) {
    this.movies = []
    this.movieName = movieName
    this.currentPage = 1
    this.getMovies(1, movieName)
  }
}
