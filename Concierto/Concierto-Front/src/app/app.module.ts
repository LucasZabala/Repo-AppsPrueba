import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdministradorComponent } from './pages/administrador/administrador.component';
import { ClienteComponent } from './pages/cliente/cliente.component';
import { EmpleadoComponent } from './pages/empleado/empleado.component';

@NgModule({
  declarations: [
    AppComponent,
    AdministradorComponent,
    ClienteComponent,
    EmpleadoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
