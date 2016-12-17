import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

import { Movie } from './../core/models/movie.model';
import { MovieService } from './../core/services/movie.service';

@Component({
    selector: 'mvdb-movies',
    templateUrl: './movies-list.component.html',
    providers: [MovieService],
})

export class MoviesListComponent implements OnInit {
    private moviesUrl = './../data/movies.json';    
    private movies: Movie[];
    private sortingProperties: string[];
    private pageTitle: string;
    private filterBy: string;
    private sortBy: string;
    private orderDesc: boolean;
    private errorMessage: string;

    constructor(private http: Http, private movieService: MovieService) { }

    getMovies() {
        this.movieService
            .getMovies()
            .subscribe(
            movies => this.movies = movies,
            error => this.errorMessage = <any>error);
    }

    ngOnInit() {
        this.pageTitle = 'Top 10 iMDB Moves';
        this.sortingProperties = ['Title', 'Rating', 'Year'];
        this.sortBy = this.sortingProperties[1];
        this.orderDesc = true;

        this.getMovies();
    }

    onInput(e: any) {
        this.filterBy = e.target.value;
    }

    onSortChange(e: any) {
        this.sortBy = e.target.value;
    }

    onOrderChange(e: any) {
        this.orderDesc = e.target.value === 'true' ? true : false;
    }
}