import { StudentTaskWithAttachments } from "src/app/shared/models/tasks/studentTaskWithAttachements";

export interface StudentState {
    scheduleActiveDate: Date;
    tasksActiveDate: Date;
    studentTasks: Array<StudentTaskWithAttachments>
}