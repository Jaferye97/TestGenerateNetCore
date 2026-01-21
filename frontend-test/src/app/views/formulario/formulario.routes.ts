import { Routes } from '@angular/router';
import { PeopleComponent } from './people/people.component';

export const FormularioRoutes: Routes = [
  {
    path: '',
    children: [{ path: '', component: PeopleComponent }],
  },
];
