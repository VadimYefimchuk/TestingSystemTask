import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Answer } from '../../models/answer';
import { TestService } from '../../services/test.service';
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
    isCheckAnswer = false;

    testResult = false;

    userAnswers: Array<Answer> = [];

    constructor(
        @Inject(MAT_DIALOG_DATA) public test: Test,
        private testService: TestService,
    ) {
        test.questions.map(question => {
            this.shuffle(question.answers);
        });
    }

    ngOnInit(): void { }

    proceedTesting(): void {
        this.isProceed = !this.isProceed;
    }

    setAnswer(answer: Answer): void {
        this.isMarked = true;

        let index = this.userAnswers.findIndex(x => x.questionId === answer.questionId)

        if (index !== -1 || null) {
            this.userAnswers[index] = answer;
        } else {
            this.userAnswers.push(answer);
        }
    }

    setIsMarkedToFalse(): void {
        this.isMarked = false;
    }

    setIsMarkedToTrue(): void {
        this.isMarked = true;
    }

    setTestResultToFalse(): void {
        this.testResult = false;
        this.isCheckAnswer = false;
    }

    getResult(): void {
        this.testService.getTestResult(this.userAnswers).subscribe(result => {
            this.testResult = result;
            this.isCheckAnswer = true;
        }, error => console.error(error));;
    }

    private shuffle(array: Array<any>): void {
        array.sort(() => Math.random() - 0.5);
    }
}
