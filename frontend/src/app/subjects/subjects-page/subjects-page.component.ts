import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { combineLatest } from 'rxjs';
import { debounceTime, filter, map, startWith } from 'rxjs/operators';
import { SubjectsService } from '../services/subjects.service';

@Component({
  selector: 'app-subjects-page',
  templateUrl: './subjects-page.component.html',
  styleUrls: ['./subjects-page.component.scss']
})
export class SubjectsPageComponent implements OnInit {

  public searchProject = new FormControl('');
  public subjects$ = combineLatest([
    this.subjectsService.subjects.pipe(
      filter(subjects => !!subjects)
    ),
    this.searchProject.valueChanges.pipe(
      startWith(''),
      debounceTime(300)
    )]).pipe(
      map(
      ([subjects, searchString]) => {
        console.log(subjects);

        return subjects.filter(subject => subject.name.toLowerCase().includes(searchString.toLowerCase()))}
    )
  )

  constructor(private subjectsService: SubjectsService) { }

  ngOnInit(): void {
  }

}
