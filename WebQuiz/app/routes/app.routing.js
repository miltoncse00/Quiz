"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var profile_1 = require("../components/profile");
var appRoutes = [
    {
        path: "",
        component: profile_1.ProfileComponent
    },
    {
        path: "profile",
        component: profile_1.ProfileComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
exports.appRouterProviders = router_1.provideRoutes(appRoutes);
//# sourceMappingURL=app.routing.js.map