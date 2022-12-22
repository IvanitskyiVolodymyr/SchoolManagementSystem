import { createAction, props } from "@ngrx/store";
import { StudentTaskAttachment } from "src/app/shared/models/attachments/studentTaskAttachment";

export const addStudentTaskAttachments = createAction(
    '[Student] Add student task attachment',
    props<{studentTaskId: number, attachment: StudentTaskAttachment}>()
);