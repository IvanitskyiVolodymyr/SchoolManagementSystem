import { ScheduleCardModel } from "./scheduleCardModel";

export interface ScheduleDay {
    schedules: Array<ScheduleCardModel>;
    date: Date;
}