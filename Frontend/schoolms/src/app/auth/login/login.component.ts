import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { UserLogin } from 'src/app/shared/models/Users/user-login';
import { loginAction } from 'src/app/store/actions/auth.actions';
import { authErrorSelector } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

  public userLogin: UserLogin = {} as UserLogin;
  public hidePassword = true; 
  public errorMessage: string | null |undefined;

  constructor(
    private store: Store
  ) { }

  ngOnInit(): void {
    this.store.select(authErrorSelector).subscribe(
      error => this.errorMessage = error
    );
  }

  public loginForm : FormGroup = new FormGroup({
    email: new FormControl('',[
      Validators.required,
      Validators.email,
      Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.maxLength(20),
      //Validators.pattern('^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$')
    ])
  });

  public submitClicked() {
    this.store.dispatch(loginAction({userLogin: this.userLogin}));
  }
}
