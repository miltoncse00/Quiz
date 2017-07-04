import { provideRoutes, Routes, RouterModule } from "@angular/router";
import { ProfileComponent } from "../components/profile";

const appRoutes: Routes = [
    {
        path: "",
        component: ProfileComponent
    },
    {
        path: "profile",
        component: ProfileComponent
    }
];

export const routing = RouterModule.forRoot(appRoutes);
export const appRouterProviders = provideRoutes(appRoutes);