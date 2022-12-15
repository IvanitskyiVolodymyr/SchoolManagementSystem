import { TaskType } from "./taskType";

export interface ResponseTaskWithGrade {
    studentTaskId: number;
    taskType: TaskType;
    startDate: Date;
    endDate:Date;
    scheduleId: number;
    title: string;
    description: string;
    gradeValue: number; 

    isChecked:boolean;
    isDone: boolean;
    isNeededToBeRedone:boolean;

    subjectTitle: string;
}