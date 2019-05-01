import { Component, OnInit } from '@angular/core';
import { MovieDatabaseService } from 'src/app/movie/service/movie-database.service';
import { MovieListItem } from '../model/movie-list-item';
import { Genre } from '../model/genre';

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  movies: MovieListItem[]

  constructor(private movieDatabaseService: MovieDatabaseService) {
    // const avengersGenres: Genre[] = [new Genre(28, 'action'), new Genre(12, 'adventure')]
    // const hellboyGenres : Genre[] = [new Genre(14, 'fantasy'), new Genre(12, 'adventure')]
    // this.movies = [
    //     new MovieListItem(299534, 'Avengers', new Date(2019,4,24), 'http://image.tmdb.org/t/p/w185/or06FN3Dka5tukK1e9sl16pB3iy.jpg', "http://image.tmdb.org/t/p/w300/7RyHsO4yDXtBv1zUU3mTpHeQ0d5.jpg", avengersGenres),
    //     new MovieListItem(456740, 'Hellboy', new Date(2019,4,10), 'http://image.tmdb.org/t/p/w185/bk8LyaMqUtaQ9hUShuvFznQYQKR.jpg', 'http://image.tmdb.org/t/p/w300/5BkSkNtfrnTuKOtTaZhl8avn4wU.jpg', hellboyGenres)
    // ]
  }

  ngOnInit() {
    this.getMovies();
  }


  getMovies(page: number = 1, quantityPage: number = 40) {
    this.movieDatabaseService.getMovies(page, quantityPage).subscribe(data => {
      console.log('movie componente')
      console.log(data)
      this.movies = data
    })
  }
}
