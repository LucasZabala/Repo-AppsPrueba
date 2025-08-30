import { Component, inject, Input } from '@angular/core';
import { Weatherforecast } from '../../services/weatherforecast';

@Component({
  selector: 'app-main',
  imports: [],
  templateUrl: './main.html',
  styleUrl: '../../../styles/main/main.scss',
})
export class Main {

  @Input() receivedTableValue!: number;

  watherForecastService = inject(Weatherforecast);
  productos: any[] = [];
  constructor() {
    this.watherForecastService.obtenerProductos().subscribe((datos) => {
      this.productos = datos;
    });
  }
}
