import { Pipe, PipeTransform } from '@angular/core';
import { Movie } from './../models/movie.model';

@Pipe({ name: 'filterMovies', pure: true })
export class FilterMoviesPipe implements PipeTransform {
    transform(items: Movie[], filterValue: string = ''): Movie[] {
        if (!items) {
            return;
        }

        if (filterValue === '') {
            return items;
        }

        return items.filter(item =>
            item.Title.toLocaleLowerCase()
                .indexOf(filterValue) > -1);
    }
}