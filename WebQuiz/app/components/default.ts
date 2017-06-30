import { Component, OnInit } from "@angular/core";
import { DemoService } from "../services/demo"

@Component({
    selector: "default-component",
    templateUrl: "/partial/default",
    providers: [DemoService]
})

export class DefaultComponent implements OnInit {
    serverTime: Date;

    constructor(private demoService: DemoService) { }

    getTimeFromServer(): void {
        this.demoService.getTime().then((result) => {
            this.serverTime = result.ServerTime;
        });
    }

    ngOnInit(): void {
        this.getTimeFromServer();
      
    }
}