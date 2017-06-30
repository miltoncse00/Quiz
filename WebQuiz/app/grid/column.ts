export class Column {
    name: string;
    descr: string;
    filter: boolean;
    constructor(name, descr, filter) {
        this.name = name;
        this.descr = descr;
        this.filter = filter;
    }
}