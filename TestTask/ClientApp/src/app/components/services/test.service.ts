import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { Answer } from './../models/answer';
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

    getTestResult(userAnswer: Array<Answer>): Observable<boolean> {
        return this.http.post<boolean>(`${this.rootURL}api/test`, userAnswer);
    }
}
