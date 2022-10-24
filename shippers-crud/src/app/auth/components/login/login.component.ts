import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      username: [null, Validators.compose([
        Validators.required,
      ])],
      password: [null, Validators.compose([
        Validators.required,
      ])]
    });
  }

  login() {
    this.authService.LogIn(this.form.controls["username"].value, this.form.controls["password"].value);
  }

  loginWithGoogleAuth() {
    this.authService.GoogleAuth();
  }
}
