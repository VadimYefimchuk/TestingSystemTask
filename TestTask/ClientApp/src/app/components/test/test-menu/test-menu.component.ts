import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Test } from '../../models/test';
import { TestService } from '../../services/test.service';
import { TestDialogComponent } from '../test-dialog/test-dialog.component';

@Component({
    selector: 'app-test-menu',
    templateUrl: './test-menu.component.html',
    styleUrls: ['./test-menu.component.css']
})
export class TestMenuComponent implements OnInit {
    testList: Array<Test>;

    constructor(
        private testService: TestService,
        private dialog: MatDialog
    ) { }

    ngOnInit(): void {
        this.testService.getTest().subscribe(result => {
            if(result && result.length) {
                this.testList = result;
            }
        }, error => console.error(error));
    }

    startTesting(test: Test) {
        this.dialog.open(TestDialogComponent, {
            data: test            
        })
    }
}
