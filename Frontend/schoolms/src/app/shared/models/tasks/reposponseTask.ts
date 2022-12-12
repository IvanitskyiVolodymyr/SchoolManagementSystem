import { TaskType } from "./taskType";

export interface ResponseTask
{
    taskId: number;
    scheduleId: number;
    taskType: TaskType;
    startDate: Date;
    endDate:Date;
    title: string;
    description: string;

    studentTaskId: number;
    isChecked:boolean;
    isDone: boolean;
    isNeededToBeRedone:boolean;
}