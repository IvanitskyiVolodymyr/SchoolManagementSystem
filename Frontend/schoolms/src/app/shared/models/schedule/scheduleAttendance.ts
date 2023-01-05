import { AttendanceStatus } from "./attendanceStatus";
import { Schedule } from "./schedule";

export interface ScheduleAttendance extends Schedule {
    subjectName: string;
    status: AttendanceStatus | null;
}
