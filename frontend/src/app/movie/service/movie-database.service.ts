import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MovieDetails } from '../model/movie-details'
import { MovieListItem } from '../model/movie-list-item';

@Injectable({
  providedIn: 'root'
})
export class MovieDatabaseService {

  private baseApi = 'http://localhost:4200/api/';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  constructor(private http: HttpClient) { }

  getMovieDetail(id: number):Observable<MovieDetails>{
    return this.http.get<MovieDetails>(this.baseApi + 'movie/'+id);
  }

  getMovies(page: number, quantityPage:number) : Observable<MovieListItem[]>{
    const movies = this.http.get<MovieListItem[]>(this.baseApi + 'movie');
    console.log('movies-service')
    console.log(movies)
    return movies;
  }
}
