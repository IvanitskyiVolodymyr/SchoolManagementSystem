import { Schedule } from "./schedule";

export interface ScheduleCardModel extends Schedule {
    title: string;
    rightPart: string | undefined;
    homeworks: Array<string> | undefined;
    planning: Array<string> | undefined;
}