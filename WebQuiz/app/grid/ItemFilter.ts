﻿import { Pipe, PipeTransform } from '@angular/core';
import { PersonFilter } from '../components/personFilter';

@Pipe({
    name: 'itemfilter',
    pure: false
})
export class ItemFilterPipe implements PipeTransform {
    transform(items: any, filter: any): any {
        if (!items || !filter) {
            return items;
        }
        // filter items array, items which match and return true will be kept, false will be filtered out
        return items.filter((item: any) => this.applyFilter(item, filter));
    }

    /**
     * Perform the filtering.
     * 
     * @param {Book} book The book to compare to the filter.
     * @param {Book} filter The filter to apply.
     * @return {boolean} True if book satisfies filters, false if not.
     */
    applyFilter(item: any, filter: any): boolean {
        for (let field in filter) {     
            if (filter[field]) {
                if (typeof filter[field] === 'string') {
                    if (item[field].toLowerCase().indexOf(filter[field].toLowerCase()) === -1) {
                        return false;
                    }
                } else if (typeof filter[field] === 'number') {
                    if (item[field] !== filter[field]) {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}