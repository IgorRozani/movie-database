import { Component, OnInit, Input } from '@angular/core';
import { MovieDetails } from '../../models/movie-details';

@Component({
  selector: 'movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})
export class MovieDetailsComponent implements OnInit {

  @Input() movie: MovieDetails;

  constructor() { }

  ngOnInit() {
  }

}
