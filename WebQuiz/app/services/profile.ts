import {Injectable}    from "@angular/core";
import { Http } from "@angular/http";
import { URLSearchParams } from "@angular/http"

declare var JSON: any;

@Injectable()
export class ProfileService {
    private apiUrl = "/api/profile/";

    constructor(private http: Http) {}


    getcities(country): Promise<any>
    {
        const url = `${this.apiUrl}/cities/${country}`;
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(response => JSON.parse(response.text()));
    }

    getWeather(country, city): Promise<any>
    {
        let data = new URLSearchParams();
        data.append('country', country);
        data.append('city', city);
        const url = `${this.apiUrl}/weather`;
        return this.http.post(url, data)
            .toPromise()
            .then(response => JSON.parse(response.text()));
    }
}