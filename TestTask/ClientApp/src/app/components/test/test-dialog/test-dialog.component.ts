import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Answer } from '../../models/answer';
import { Question } from '../../models/question';
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

    testAnswerId: Array<number> = [];
    testAnswerIsCorrect: Array<boolean> = [];
    testResult = false;

    constructor(
        @Inject(MAT_DIALOG_DATA) public test: Test,
    ) {
        test.questions.map(question => {
            this.shuffle(question.answers);
        });
    }

    ngOnInit(): void { }

    proceedTesting(): void {
        this.isProceed = !this.isProceed;
    }

    setAnswer(question: Question, answer: Answer): void {
        this.isMarked = true;

        var index = (this.testAnswerId && this.testAnswerId.length) 
                    ? this.testAnswerId.indexOf(question.id) 
                    : -1;

        if (index !== -1) {
            this.testAnswerIsCorrect[index] = answer.isCorrect;
        } else {
            this.testAnswerId.push(question.id);
            this.testAnswerIsCorrect.push(answer.isCorrect);
        }

        this.isTestResultCorrect();
    }

    isTestResultCorrect(): void {
        let answerCount = 0;

        this.testAnswerIsCorrect.forEach(element => {
            if (element) {
                answerCount++;
            }
        });
        
        this.testResult = answerCount === this.test.questions.length;
    }

    setIsMarkedToFalse(): void {
        this.isMarked = false;
    }

    setIsMarkedToTrue(): void {
        this.isMarked = true;
    }

    setTestResultToFalse(): void {
        this.testResult = false;
        this.testAnswerId = [];
        this.testAnswerIsCorrect = [];
    }

    private shuffle(array: Array<any>): void {
        array.sort(() => Math.random() - 0.5);
    }
}
