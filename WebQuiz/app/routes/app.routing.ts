import { provideRoutes, Routes, RouterModule } from "@angular/router";
import { WeatherComponent } from "../components/weather";

const appRoutes: Routes = [
    {
        path: "",
        component: WeatherComponent
    },
    {
        path: "weather",
        component: WeatherComponent
    }
];

export const routing = RouterModule.forRoot(appRoutes);
export const appRouterProviders = provideRoutes(appRoutes);