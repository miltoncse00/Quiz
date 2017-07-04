import { Component, OnInit } from "@angular/core";
import { ProfileService } from "../services/profile"

@Component({
    selector: "profile-component",
    templateUrl: "/partial/profile",
    providers: [ProfileService]
})

export class ProfileComponent implements OnInit {
    weather: any;
    country: string;
    city :string;
    cities:string[];
    constructor(private profileService: ProfileService) { }

    ngOnInit(): void {
       
    }

    valuechange(newValue:string) {
        if (newValue.length >= 2) {
            this.country = newValue;
            this.populateCities(this.country);
        } else {
            this.cities = [];
        }
    }

    populateCities(country) {
        this.profileService.getcities(country).then((cities) => {
            this.cities = cities;
            console.info(cities);
        });
    }
    selectCities(value) {
        this.city = value;
        this.profileService.getWeather(this.country, this.city).then((weather) => {
            this.weather = weather;
            console.info(weather);
        });
       console.info(value);
    }
}