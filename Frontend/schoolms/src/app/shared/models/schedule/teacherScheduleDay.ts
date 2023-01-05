import { ScheduleWithClassSubject } from "./scheduleWithClassSubject";

export interface TeacherScheduleDay {
    schedules: Array<ScheduleWithClassSubject>;
    date: Date;
}