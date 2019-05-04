import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MovieDetails } from '../models/movie-details'
import { MovieListItem } from '../models/movie-list-item';

@Injectable({
  providedIn: 'root'
})
export class MovieDatabaseService {

  private baseApi = 'http://localhost:4200/api/';

  constructor(private http: HttpClient) { }

  getMovieDetail(id: number): Observable<MovieDetails> {
    return this.http.get<MovieDetails>(this.baseApi + 'movie/' + id);
  }

  getMovies(page: number = 1, quantityPage: number = 40, movieName: string = null): Observable<MovieListItem[]> {
    return this.http.get<MovieListItem[]>(`${this.baseApi}movie?page=${page}&quantityPage=${quantityPage}&movieName=${movieName}`);
  }
}
