import { Component } from '@angular/core';
import { UserService } from '../../services/user.services';


@Component({
    selector: 'home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    public password: string = "";
    public username: string = "";
    
    constructor(private userService: UserService) {

    }

    public submit(): void {
        this.userService.Add({
            name: this.username,
            score: 0,
            chores: []
        }).then(() => {
            //clear when success
            this.username = "";
            this.password = "";
        })
    }
}
