import {Injectable}    from "@angular/core";
import {Http} from "@angular/http";

declare var JSON: any;

@Injectable()
export class ProfileService {
    private apiUrl = "/api/profile/";

    constructor(private http: Http) { }

    get() : Promise<any> {
       const url = `${this.apiUrl}current`;
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(response => JSON.parseWithDate(response.text())); 
    }    
}