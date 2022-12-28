import { GradeType } from "./gradeType";

export interface ClassSubjectGrade  {
    classSubjectGradeId: number;
    gradeType: GradeType;
    classSubjectId: number;
    studentId: number;
    grade: number
}