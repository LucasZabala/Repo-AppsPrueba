import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministradorComponent } from './pages/administrador/administrador.component';
import { EmpleadoComponent } from './pages/empleado/empleado.component';
import { ClienteComponent } from './pages/cliente/cliente.component';

const routes: Routes = [
  { path: 'cliente', component: ClienteComponent },
  { path: 'administrador', component: AdministradorComponent },
  { path: 'empleado', component: EmpleadoComponent },
  { path: '', redirectTo: '/cliente', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
