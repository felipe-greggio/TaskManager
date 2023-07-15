import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[AuthService]
})
export class LoginComponent {

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });


  constructor(private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) {


  }

  ngOnInit(){

  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value.email!, this.loginForm.value.password!).subscribe(response =>{
        if(response.success){
          window.alert(response.message);
          localStorage.setItem('token', response.data);
          this.router.navigate(['/projects']);
        }else if(!response.success){
          window.alert(response.message);
          this.resetForm();
        }});
    }
  }

  private resetForm() {
    this.loginForm.reset();
  }

}
