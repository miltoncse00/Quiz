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
var demo_1 = require("../services/demo");
var DefaultComponent = (function () {
    function DefaultComponent(demoService) {
        this.demoService = demoService;
    }
    DefaultComponent.prototype.getTimeFromServer = function () {
        var _this = this;
        this.demoService.getTime().then(function (result) {
            _this.serverTime = result.ServerTime;
        });
    };
    DefaultComponent.prototype.ngOnInit = function () {
        this.getTimeFromServer();
    };
    return DefaultComponent;
}());
DefaultComponent = __decorate([
    core_1.Component({
        selector: "default-component",
        templateUrl: "/partial/default",
        providers: [demo_1.DemoService]
    }),
    __metadata("design:paramtypes", [demo_1.DemoService])
], DefaultComponent);
exports.DefaultComponent = DefaultComponent;
//# sourceMappingURL=default.js.map