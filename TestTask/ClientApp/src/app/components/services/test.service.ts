import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { Test } from './../models/test';

@Injectable({ 
    providedIn: 'root' 
})
export class TestService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private rootURL: string
    ) { }

    getTests(): Observable<Array<Test>> {
        return this.http.get<Array<Test>>(`${this.rootURL}api/test`);
    }
}
