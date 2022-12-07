import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserLogin } from 'src/app/shared/models/Users/user-login';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

  public userLogin: UserLogin = {} as UserLogin;
  public hidePassword = true;

  constructor(
    private authService: AuthService
  ) { }

  ngOnInit(): void {
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
    this.authService.login(this.userLogin).subscribe(res => console.log(res))
  }
}
