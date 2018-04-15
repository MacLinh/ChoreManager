import { Component } from '@angular/core';
import { UserService, User } from '../../services/user.services';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
    
    public users: User[] = [];

    public selectedUser: User | undefined;

    constructor(private userService: UserService) {

    }
    ngOnInit(): void {
        this.userService.GetAll().then(users => this.users = users);
    }

    selectUser(user: User) {
        this.selectedUser = user;

        //load the user's chores
        this.userService.Get(this.selectedUser.name)
            .then(result => this.selectedUser = result);
    }

}
