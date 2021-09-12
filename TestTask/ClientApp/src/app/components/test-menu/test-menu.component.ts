import { Test } from './../models/test';
import { Component, OnInit } from '@angular/core';
import { TestService } from '../services/test.service';

@Component({
    selector: 'app-test-menu',
    templateUrl: './test-menu.component.html',
    styleUrls: ['./test-menu.component.css']
})
export class TestMenuComponent implements OnInit {
    testList: Array<Test>;

    constructor(
        private testService: TestService
    ) { }

    ngOnInit(): void {
        this.testService.getTest().subscribe(result => {
            if(result && result.length) {
                this.testList = result;
            }
        }, error => console.error(error));
    }
}
