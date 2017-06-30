import { Component, NgZone, OnInit, ViewChild, OnDestroy } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: "my-app",
    templateUrl: "/partial/main",
    providers: []
})

export class AppComponent implements OnInit, OnDestroy {
    constructor(
        private router: Router
    ) { }

    isActive(instruction: string): boolean {        
        instruction = instruction === "" ? "/" : instruction;
        return this.router.url === instruction;
    }

    ngOnInit(): void { }

    ngOnDestroy(): void { }
}