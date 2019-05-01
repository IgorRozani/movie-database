import { Genre } from './genre';

export class MovieListItem {
    id: number
    title: string
    releaseDate: Date
    posterPath: string
    backdropPath: string
    genres: Genre[]

    constructor(id: number, title: string, releaseDate: Date, posterPath: string, backdropPath: string, genres: Genre[]) {
        this.id = id
        this.title = title
        this.releaseDate = releaseDate
        this.posterPath = posterPath
        this.backdropPath = backdropPath
        this.genres = genres
    }
}
