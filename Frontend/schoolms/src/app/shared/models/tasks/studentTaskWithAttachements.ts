import { StudentTaskAttachment } from "../attachments/studentTaskAttachment";

export interface StudentTaskWithAttachments {
    studentTaskId: number;
    attachments: Array<StudentTaskAttachment>
}