import { Question } from './question';

export interface Test {
    id: number;
    testName: string;
    description: string;
    imageUrl: string;
    questions: Array<Question>;
}