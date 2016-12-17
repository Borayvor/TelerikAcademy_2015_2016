import { Component, Input } from '@angular/core';

import { Movie } from './../core/models/movie.model';

@Component({
    selector: '[mvdb-movie-short]',
    styleUrls: ['./movie-short.component.css'],
    templateUrl: './movie-short.component.html',
    providers: [],
})

export class MovieShortComponent {

    @Input() movie: Movie;

    get imdbRating(): string {
        return this.movie.imdbRating;
    }

    get poster(): string {
        return this.movie.Poster;
    }

    get title(): string {
        return this.movie.Title;
    }

    get year(): string {
        return this.movie.Year;
    }
}