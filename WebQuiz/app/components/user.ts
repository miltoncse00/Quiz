import { Component, OnInit } from "@angular/core";
import { UserService } from "../services/user"
import { Column } from "../grid/Column"
import { Sorter } from "../grid/sorter"
import { PersonFilter } from "../components/personFilter"


@Component({
    selector: "user-component",
    templateUrl: "/partial/users",    
    providers: [UserService]

})


export class UserComponent implements OnInit {
    public users= [];
    public columns = [];
    public filter: PersonFilter;
    constructor(private userService: UserService) {
        this.filter = new PersonFilter();
        this.columns.push(new Column('Email', 'Email', true));
        this.columns.push(new Column('Name', 'Name', true));
        this.columns.push(new Column('LastName', 'Last Name', false));
        this.columns.push(new Column('DateOfBirth', 'Date Of Birth',false));
        this.columns.push(new Column('MonthlySalary', 'Monthly Salary',false));
    }

    ngOnInit(): void {
        this.userService.get().then((users) => {
            this.users = users;
            console.info(users);
        });
    }
}