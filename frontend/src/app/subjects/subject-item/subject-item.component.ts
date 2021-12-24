import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { UserSubject } from 'src/app/shared/models/userSubject';

@Component({
  selector: 'app-subject-item',
  templateUrl: './subject-item.component.html',
  styleUrls: ['./subject-item.component.scss']
})
export class SubjectItemComponent implements OnInit {

  @Input() 
  public subject!: UserSubject;

  constructor(private _sanitizer: DomSanitizer) { }

  ngOnInit(): void {
  }

}
