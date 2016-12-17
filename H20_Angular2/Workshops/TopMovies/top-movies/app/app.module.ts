
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { MoviesListComponent } from './movie/movies-list.component';
import { MovieShortComponent } from './movie/movie-short.component';

import { SortMoviesPipe } from './core/pipes/sort-movies.pipe';
import { FilterMoviesPipe } from './core/pipes/filter-movies.pipe';

import { MovieService } from './core/services/movie.service';

@NgModule({
    imports: [BrowserModule, HttpModule ],
    declarations: [
        AppComponent, 
        MoviesListComponent, 
        MovieShortComponent,
        SortMoviesPipe,
        FilterMoviesPipe],
    providers: [MovieService],
    bootstrap: [AppComponent]
})

export class AppModule { }
