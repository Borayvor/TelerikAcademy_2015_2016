import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { Movie } from './../models/movie.model';

@Injectable()
export class MovieService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private moviesUrl = './../../data/movies.json';

    constructor(private http: Http) { }

    getMovies(): Observable<Movie[]> {
        return this.http.get(this.moviesUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}