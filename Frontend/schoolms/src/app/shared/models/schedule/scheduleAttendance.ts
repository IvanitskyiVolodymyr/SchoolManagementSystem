import { AttendanceStatus } from "./attendanceStatus";

export interface ScheduleAttendance {
    scheduleId: number;
    startTime: Date;
    classSubjectId: number;
    subjectName: string;
    endTime: Date;
    place: string;
    status: AttendanceStatus | null;
}
