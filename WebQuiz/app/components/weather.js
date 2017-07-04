"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var weather_1 = require("../services/weather");
var WeatherComponent = (function () {
    function WeatherComponent(weatherService) {
        this.weatherService = weatherService;
    }
    WeatherComponent.prototype.ngOnInit = function () {
    };
    WeatherComponent.prototype.valuechange = function (newValue) {
        if (newValue.length >= 2) {
            this.country = newValue;
            this.populateCities(this.country);
        }
        else {
            this.cities = [];
        }
    };
    WeatherComponent.prototype.populateCities = function (country) {
        var _this = this;
        this.weatherService.getcities(country).then(function (cities) {
            _this.cities = cities;
            console.info(cities);
        });
    };
    WeatherComponent.prototype.selectCities = function (value) {
        var _this = this;
        this.city = value;
        this.weatherService.getWeather(this.country, this.city).then(function (weather) {
            _this.weather = weather;
            console.info(weather);
        });
        console.info(value);
    };
    return WeatherComponent;
}());
WeatherComponent = __decorate([
    core_1.Component({
        selector: "weather-component",
        templateUrl: "/partial/weather",
        providers: [weather_1.WeatherService]
    }),
    __metadata("design:paramtypes", [weather_1.WeatherService])
], WeatherComponent);
exports.WeatherComponent = WeatherComponent;
//# sourceMappingURL=weather.js.map