import { ScheduleAttendance } from "./scheduleAttendance";

export interface ScheduleDay {
    schedules: Array<ScheduleAttendance>;
    date: Date;
}