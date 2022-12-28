import { GradeType } from "./gradeType";

export interface Grade {
    gradeId: number;
    value: number;
    studentTaskId: number;
    gradeType: GradeType
}