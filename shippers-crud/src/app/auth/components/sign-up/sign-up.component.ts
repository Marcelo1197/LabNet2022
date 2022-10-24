import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      email: [null, Validators.compose([
        Validators.required,
        Validators.email
      ])],
      password: [null, Validators.compose([
        Validators.required,
      ])],
    });
  }

  signUp() {
    this.authService.SignUp(this.form.controls['email'].value, this.form.controls['password'].value);
  }

  signUpGoogleAuth() {
    this.authService.GoogleAuth();
  }

}


//usar authService.SignUp(userEmail.value, userPwd.value) y authService.GoogleAuth()
