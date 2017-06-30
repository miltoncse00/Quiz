import { Component } from '@angular/core';
import { Column } from './column';
import { Sorter } from './sorter';

@Component({
    selector: 'grid',
    inputs: ['rows: rows', 'columns: columns','filter:filter'],
    templateUrl: './app/grid/grid.html'
})
export class Grid {
    columns: Array<Column>;
    rows: Array<any>;
    sorter: Sorter;
    filter: any;
    constructor() {
        this.sorter = new Sorter();
    }
    sort(key) {
        this.sorter.sort(key, this.rows);
    }
}
