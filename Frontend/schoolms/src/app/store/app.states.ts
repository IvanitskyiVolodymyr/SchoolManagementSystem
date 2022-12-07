import * as auth from './states/authUser.state';

export interface AppState {
  authState: auth.AuthUserState;
}