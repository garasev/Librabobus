import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { MatIconModule } from '@angular/material/icon';
import { AuthRoutingModule } from './auth-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AuthPageComponent,
    RegistrationPageComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    MatIconModule,
    HttpClientModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class AuthModule { }
