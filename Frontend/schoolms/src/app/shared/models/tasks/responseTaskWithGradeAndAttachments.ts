import { StudentTaskAttachment } from "../attachments/studentTaskAttachment";
import { ResponseTaskWithGrade } from "./responseTaskWithGrade";

export interface ResponseTaskWithGradeAndAttachments extends ResponseTaskWithGrade { 
    attachments: Array<StudentTaskAttachment>
}