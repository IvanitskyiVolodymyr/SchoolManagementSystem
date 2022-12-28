import { Grade } from "./grade";

export interface SubjectGrade {
    classSubjectId: number;
    subjectName: string;
    grades: Array<Grade>;
    finalGrades: Array<Grade>;
}