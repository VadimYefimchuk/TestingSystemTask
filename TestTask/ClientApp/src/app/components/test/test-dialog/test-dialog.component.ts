import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Test } from './../../models/test';

@Component({
    selector: 'app-test-dialog',
    templateUrl: './test-dialog.component.html',
    styleUrls: ['./test-dialog.component.css']
})
export class TestDialogComponent implements OnInit {
    isProceed: boolean;
    isChecked: false;

    constructor(
        @Inject(MAT_DIALOG_DATA) public test: Test,
    ) { 
        this.isProceed = false;
    }

  ngOnInit() { }

    proceedTesting() {
        this.isProceed = !this.isProceed;
    }
}
