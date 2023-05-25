import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });


  constructor(private fb: FormBuilder) {


  }

  ngOnInit(){

  }

  onSubmit() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      // here you should handle form data and pass it to your login method
    }
  }


}
