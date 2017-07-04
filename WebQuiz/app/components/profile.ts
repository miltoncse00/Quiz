import { Component, OnInit } from "@angular/core";
import { ProfileService } from "../services/profile"

@Component({
    selector: "profile-component",
    templateUrl: "/partial/profile",
    providers: [ProfileService]
})

export class ProfileComponent implements OnInit {
    profile: any;
    country: string;
    cities:string[];
    constructor(private profileService: ProfileService) { }

    ngOnInit(): void {
        this.profileService.get().then((profile) => {
            this.profile = profile;
            console.info(profile);
        });
    }

    valuechange(newValue:string) {
        if (newValue.length >= 2) {
            this.country = newValue;
            this.populateCities(this.country);
        } else {
            this.cities = [];
        }
    }

    populateCities(country) {
        this.profileService.getcities(country).then((cities) => {
            this.cities = cities;
            console.info(cities);
        });
    }
    selectCities(value) {
       console.info(value);
    }
}