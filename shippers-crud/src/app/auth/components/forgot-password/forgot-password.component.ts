import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      email: [null, Validators.compose([
        Validators.required,
        Validators.email
      ])]
    });
  }

  forgotPassword() {
    this.authService.ForgotPassword(this.form.controls['email'].value);
  }
}


//authService.ForgotPassword(passwordResetEmail.value)"
