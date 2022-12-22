import { createReducer, on } from "@ngrx/store";
import { StudentState } from "../states/student.state";
import * as StudentActions from "../actions/student.actions"
import { StudentTaskAttachment } from "src/app/shared/models/attachments/studentTaskAttachment";
import { StudentTaskWithAttachments } from "src/app/shared/models/tasks/studentTaskWithAttachements";

export const initStudentState: StudentState = {
    scheduleActiveDate: new Date(),
    tasksActiveDate: new Date(),
    studentTasks: []
};

export const studentFeatureKey = 'student';

export const studentReducer = createReducer(
    initStudentState,
    on(StudentActions.addStudentTaskAttachments, (state, action) => ({
        ...state,
        studentTasks: AddStudentTaskAttachment(state.studentTasks, action.studentTaskId, action.attachment)
    })),
);

function AddStudentTaskAttachment(studentTasks: Array<StudentTaskWithAttachments>, studentTaskId: number, attachment: StudentTaskAttachment) {
    studentTasks = [...studentTasks];
    const studentTask = studentTasks.filter( t=> t.studentTaskId == studentTaskId)[0] as StudentTaskWithAttachments;
    const index = studentTasks.indexOf(studentTask);

    if(studentTask) {
        const newStudentTask = Object.assign({}, studentTask, {attachments: [...studentTask.attachments], studentTaskId: studentTaskId}); 
        newStudentTask.attachments.push(attachment);
        studentTasks[index] = newStudentTask;
        
    } else {
        const newStudentTask : StudentTaskWithAttachments = { studentTaskId: studentTaskId, attachments: []} as StudentTaskWithAttachments;
        newStudentTask.attachments.push(attachment);
        studentTasks.push(newStudentTask);
    }
    return studentTasks;
}
