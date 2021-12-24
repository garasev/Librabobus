import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AuthPageComponent implements OnInit {

  readonly description = 'Чтобы продолжить, войди в аккаунт.'
  constructor() { }

  ngOnInit(): void {
  }

}
