import { createFeatureSelector, createSelector } from "@ngrx/store";
import { studentFeatureKey } from "../reducers/student.reducer";
import { StudentState } from "../states/student.state";

export const studentSelector = createFeatureSelector<StudentState>(studentFeatureKey);
export const selectAllStudentTasks = createSelector(studentSelector, state => state.studentTasks);

export const selectStudentTaskAttachments = (studentTaskId: number) => createSelector(
    selectAllStudentTasks,
    (tasks) => tasks.filter(t => t.studentTaskId == studentTaskId)
);