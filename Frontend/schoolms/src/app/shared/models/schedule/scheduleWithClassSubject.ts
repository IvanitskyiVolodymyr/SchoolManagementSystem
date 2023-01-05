import { Schedule } from "./schedule";

export interface ScheduleWithClassSubject extends Schedule{
    subjectName: string;
    classNumber: string;
    classLetter: string;
}