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
var user_1 = require("../services/user");
var Column_1 = require("../grid/Column");
var personFilter_1 = require("../components/personFilter");
var UserComponent = (function () {
    function UserComponent(userService) {
        this.userService = userService;
        this.users = [];
        this.columns = [];
        this.filter = new personFilter_1.PersonFilter();
        this.columns.push(new Column_1.Column('Email', 'Email', true));
        this.columns.push(new Column_1.Column('Name', 'Name', true));
        this.columns.push(new Column_1.Column('LastName', 'Last Name', false));
        this.columns.push(new Column_1.Column('DateOfBirth', 'Date Of Birth', false));
        this.columns.push(new Column_1.Column('MonthlySalary', 'Monthly Salary', false));
    }
    UserComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.userService.get().then(function (users) {
            _this.users = users;
            console.info(users);
        });
    };
    return UserComponent;
}());
UserComponent = __decorate([
    core_1.Component({
        selector: "user-component",
        templateUrl: "/partial/users",
        providers: [user_1.UserService]
    }),
    __metadata("design:paramtypes", [user_1.UserService])
], UserComponent);
exports.UserComponent = UserComponent;
//# sourceMappingURL=user.js.map