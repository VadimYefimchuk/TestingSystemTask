import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Answer } from '../../models/answer';
import { Test } from './../../models/test';

@Component({
    selector: 'app-test-dialog',
    templateUrl: './test-dialog.component.html',
    styleUrls: ['./test-dialog.component.css']
})
export class TestDialogComponent implements OnInit {
    isProceed = false;
    isChecked = false;
    isMarked = false;
    testResult = 0;

    constructor(
        @Inject(MAT_DIALOG_DATA) public test: Test,
    ) {
        test.questions.map(question => {
            this.shuffle(question.answers);
        });
    }

    ngOnInit() {
    }

    proceedTesting(): void {
        this.isProceed = !this.isProceed;
    }

    setAnswer(answer: Answer): void {
        this.isMarked = true;

        if (answer.isCorrect) {
            this.testResult ++;
        }
    }

    setIsMarkedToFalse() {
        this.isMarked = false;
    }

    setIsMarkedToTrue() {
        this.isMarked = true;
    }

    setTestResultToZero() {
        this.testResult = 0;
    }

    private shuffle(array: Array<any>): void {
        array.sort(() => Math.random() - 0.5);
    }
}
