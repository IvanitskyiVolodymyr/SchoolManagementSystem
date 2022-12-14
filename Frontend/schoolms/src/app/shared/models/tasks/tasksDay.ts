import { ResponseTaskWithGrade } from "./responseTaskWithGrade";

export interface TasksDay {
    tasks: ResponseTaskWithGrade[];
    date: Date;
}