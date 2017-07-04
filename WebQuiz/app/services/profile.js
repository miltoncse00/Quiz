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
var ProfileService = (function () {
    function ProfileService(http) {
        this.http = http;
        this.apiUrl = "/api/profile/";
    }
    ProfileService.prototype.get = function () {
        var url = this.apiUrl + "current";
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(function (response) { return JSON.parseWithDate(response.text()); });
    };
    ProfileService.prototype.getcities = function (country) {
        var url = this.apiUrl + "/cities/" + country;
        return this.http.get(url, { body: "" })
            .toPromise()
            .then(function (response) { return JSON.parse(response.text()); });
    };
    return ProfileService;
}());
ProfileService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], ProfileService);
exports.ProfileService = ProfileService;
//# sourceMappingURL=profile.js.map