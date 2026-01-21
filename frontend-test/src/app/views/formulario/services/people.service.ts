import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { People } from '../interfaces/people';
import { PEOPLE_DUMMY_DATA } from './people-dummy.data';

@Injectable({
  providedIn: 'root',
})
export class PeopleService {
  constructor(private http: HttpClient) {}

  /** GET con filtros */
  getPeople(filters?: {
    name?: string;
    age?: number;
    email?: string;
  }): Observable<People[]> {
    let result = PEOPLE_DUMMY_DATA;

    if (filters) {
      result = result.filter((person) => {
        const matchName = filters.name
          ? person.name.toLowerCase().includes(filters.name.toLowerCase())
          : true;

        const matchAge = filters.age ? person.age === filters.age : true;

        const matchEmail = filters.email
          ? person.email.toLowerCase().includes(filters.email.toLowerCase())
          : true;

        return matchName && matchAge && matchEmail;
      });
    }

    return of(result);
  }

  /** INSERT People (dummy data) */
  insertPeople(): Observable<People> {
    const urlConsulta = `${environment.urlInicial}${urlServices.people}`;

    const dummyPeople: People = {
      name: 'Juan',
      lastName: 'Pérez',
      age: 30,
      email: 'juan.perez@test.com',
    };

    return this.http.post<People>(urlConsulta, dummyPeople);
  }
}
