import { Routes } from '@angular/router';
import { FormularioRoutes } from './views/formulario/formulario.routes';

export const routes: Routes = [
  ...FormularioRoutes,
  { path: '**', redirectTo: '' },
];
