import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AuthPageComponent implements OnInit {

  readonly description = 'Чтобы продолжить, войди в аккаунт.'

  public authForm: FormGroup = this.fb.group({
    login: [null, [Validators.required]],
    password: [null, [Validators.required]],
  });
  
  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
  ) { }

  ngOnInit(): void {
  }

  public signIn() {
    console.log('zali')
    if (this.authForm.invalid) {
      return;
    }
    const { login, password } = this.authForm.value;

    this.auth.login(login, password);
  }

}
