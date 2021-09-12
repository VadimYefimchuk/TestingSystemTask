import { Answer } from './answer';

export interface Question {
    id: number;
    questionText: string;
    testId: number;
    answers: Array<Answer>;
}