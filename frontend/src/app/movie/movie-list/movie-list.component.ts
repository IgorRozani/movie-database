import { Component, OnInit } from '@angular/core';
import { MovieDatabaseService } from 'src/app/movie/service/movie-database.service';
import { MovieListItem } from '../model/movie-list-item';
import { isUndefined } from 'util';

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  movies: MovieListItem[];
  private currentPage: number = 1;

  constructor(private movieDatabaseService: MovieDatabaseService) {
  }

  ngOnInit() {
    this.movies = [];
    this.getMovies();
  }

  getMovies(page: number = 1, quantityPage: number = 40) {
    this.movieDatabaseService.getMovies(page, quantityPage).subscribe(data => {
      data.forEach(d => this.movies.push(d))
    })
  }

  onScroll() {
    this.currentPage++
    this.getMovies(this.currentPage)
  }
}
