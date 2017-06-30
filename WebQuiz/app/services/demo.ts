import {Injectable}    from "@angular/core";
import {Http} from "@angular/http";

declare var JSON: any;

@Injectable()
export class DemoService {
    private apiUrl = "/api/demo/";

    constructor(private http: Http) { }

    getTime() : Promise<any> {
       const url = `${this.apiUrl}time`;
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(response => JSON.parseWithDate(response.text())); 
    }

    notifyBuildSuccess() : Promise<any> {
       const url = `${this.apiUrl}buildsuccess`;
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(response => response.text()); 
    }
}