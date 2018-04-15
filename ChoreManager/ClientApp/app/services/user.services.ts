import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class UserService {

    private readonly endpoint = "/api/user";

    constructor(private http: Http) { }

    public Add(user: User): Promise<void> {
        return this.http.post(this.endpoint, user)
            .toPromise()
            .then(response => {
                //assert response.status is 201 created
            });
    }

    public GetAll(): Promise<User[]> {
        return this.http.get(this.endpoint)
            .toPromise()
            .then<User[]>(response =>
                response.json() as User[]
            );
    }

    public Get(name: string): Promise<User> {
        return this.http.get(this.endpoint + '/' + name)
            .toPromise()
            .then<User>(response =>
                response.json() as User
            );
    }
}

export interface User {
    name: string;
    score: number;
    chores: any[];
}