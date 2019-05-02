import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MovieDetails } from '../model/movie-details'
import { MovieListItem } from '../model/movie-list-item';
import { isUndefined } from 'util';

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

  getMovieDetail(id: number): Observable<MovieDetails> {
    return this.http.get<MovieDetails>(this.baseApi + 'movie/' + id);
  }

  getMovies(page: number = 1, quantityPage: number = 40): Observable<MovieListItem[]> {
    return this.http.get<MovieListItem[]>(`${this.baseApi}movie?page=${page}&quantityPage=${quantityPage}`);
  }
}
