import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { authGuard } from './guards/auth.guard'; 

// Componentes de las diferentes secciones
import { ClientComponent } from './pages/client/client.component';
import { AdminComponent } from './pages/admin/admin.component';
import { EmployComponent } from './pages/employ/employ.component';

const routes: Routes = [
  // Rutas de autenticación
  { path: 'login', component: LoginComponent },

  // Rutas de registro específicas por rol
  { path: 'cliente/register', component: RegisterComponent, data: { role: 'Client' } },
  { path: 'administrador/register', component: RegisterComponent, data: { role: 'Admin' } },
  { path: 'empleado/register', component: RegisterComponent, data: { role: 'Employee' } },

  // Rutas para clientes
  {
    path: 'cliente',
    canActivate: [authGuard],
    data: { roles: ['Client'] },
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: ClientComponent },
      // Otras rutas de cliente...
    ],
  },
  
  // Rutas para administradores
  {
    path: 'administrador',
    canActivate: [authGuard],
    data: { roles: ['Admin'] },
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: AdminComponent },
      // Otras rutas de administrador...
    ],
  },

  // Rutas para empleados
  {
    path: 'empleado',
    canActivate: [authGuard],
    data: { roles: ['Employee'] },
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: EmployComponent },
      // Otras rutas de empleado...
    ],
  },

  // Ruta de acceso denegado
  { path: 'access-denied', component: AccessDeniedComponent },

  // Redirigir cualquier otra ruta no válida a login
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}