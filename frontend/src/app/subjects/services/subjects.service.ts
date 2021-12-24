import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ApiService } from 'src/app/core/api/api.service';
import { UserSubject } from 'src/app/shared/models/userSubject';



@Injectable({
  providedIn: 'root'
})
export class SubjectsService {

  public subjects = new BehaviorSubject<UserSubject[]>([]);
  
  constructor(private readonly api: ApiService) {
    this.initialSubject();
  }

  async initialSubject() {
    const id = localStorage.getItem('userLogin');
    if (!id)
      return;
    
    const subject = await this.api.getUserSubject(id).toPromise();
    this.subjects.next(subject);
  }

}
