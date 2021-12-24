import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ApiService } from 'src/app/core/api/api.service';
import { UserSubject } from 'src/app/shared/models/userSubject';



@Injectable({
  providedIn: 'root'
})
export class SubjectsService {

  public subjects = new BehaviorSubject<UserSubject[]>([]);
  
  constructor(api: ApiService) {
    this.initialSubject();
  }

  initialSubject() {
    const subject: UserSubject[] = [{
        id: '',
        ownerId: '',
        name: 'penis',
        privat: true,
        description: 'zalupa',
        photoBase64: 'her',
    },
    {
        id: '',
        ownerId: '',
        name: 'aaas',
        privat: true,
        description: 'zalupa',
        photoBase64: 'her',
    }]

    this.subjects.next(subject);
  }

}
