//src/app/app.ts
import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Weatherforecast } from './weatherforecast';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  watherForecastService = inject(Weatherforecast);
  productos: any[] = [];
  constructor() {
    this.watherForecastService.obtenerProductos().subscribe((datos) => {
      this.productos = datos;
    });
  }
}
