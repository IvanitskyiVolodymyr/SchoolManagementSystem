import * as auth from './states/authUser.state';
import * as student from './states/student.state';


export interface AppState {
  authState: auth.AuthUserState;
  studentState: student.StudentState;
}