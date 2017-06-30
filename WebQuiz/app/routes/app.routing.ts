import { provideRoutes, Routes, RouterModule } from "@angular/router";
import { DefaultComponent } from "../components/default";
import { ProfileComponent } from "../components/profile";
import { UserComponent } from "../components/user";

const appRoutes: Routes = [
    {
        path: "",
        component: DefaultComponent
    },
    {
        path: "profile",
        component: ProfileComponent
    },
    {
        path: "user",
        component: UserComponent
    },
];

export const routing = RouterModule.forRoot(appRoutes);
export const appRouterProviders = provideRoutes(appRoutes);