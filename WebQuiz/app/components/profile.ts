import { Component, OnInit } from "@angular/core";
import { ProfileService } from "../services/profile"

@Component({
    selector: "profile-component",
    templateUrl: "/partial/profile",
    providers: [ProfileService]
})

export class ProfileComponent implements OnInit {
    profile: any;

    constructor(private profileService: ProfileService) { }

    ngOnInit(): void {
        this.profileService.get().then((profile) => {
            this.profile = profile;
            console.info(profile);
        });
    }
}