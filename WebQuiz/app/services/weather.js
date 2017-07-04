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
var http_1 = require("@angular/http");
var http_2 = require("@angular/http");
var WeatherService = (function () {
    function WeatherService(http) {
        this.http = http;
        this.apiUrl = "/api/weather/";
    }
    WeatherService.prototype.getcities = function (country) {
        var url = this.apiUrl + "/cities/" + country;
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(function (response) { return JSON.parse(response.text()); });
    };
    WeatherService.prototype.getWeather = function (country, city) {
        var data = new http_2.URLSearchParams();
        data.append('country', country);
        data.append('city', city);
        var url = this.apiUrl + "/weather";
        return this.http.post(url, data)
            .toPromise()
            .then(function (response) { return JSON.parse(response.text()); });
    };
    return WeatherService;
}());
WeatherService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], WeatherService);
exports.WeatherService = WeatherService;
//# sourceMappingURL=weather.js.map