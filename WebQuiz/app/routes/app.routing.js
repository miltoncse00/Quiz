"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var weather_1 = require("../components/weather");
var appRoutes = [
    {
        path: "",
        component: weather_1.WeatherComponent
    },
    {
        path: "weather",
        component: weather_1.WeatherComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
exports.appRouterProviders = router_1.provideRoutes(appRoutes);
//# sourceMappingURL=app.routing.js.map