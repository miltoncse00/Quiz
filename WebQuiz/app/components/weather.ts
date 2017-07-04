import { Component, OnInit } from "@angular/core";
import { WeatherService } from "../services/weather"

@Component({
    selector: "weather-component",
    templateUrl: "/partial/weather",
    providers: [WeatherService]
})

export class WeatherComponent implements OnInit {
    weather: any;
    country: string;
    city :string;
    cities:string[];
    constructor(private weatherService: WeatherService) { }

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
        this.weatherService.getcities(country).then((cities) => {
            this.cities = cities;
            console.info(cities);
        });
    }
    selectCities(value) {
        this.city = value;
        this.weatherService.getWeather(this.country, this.city).then((weather) => {
            this.weather = weather;
            console.info(weather);
        });
       console.info(value);
    }
}