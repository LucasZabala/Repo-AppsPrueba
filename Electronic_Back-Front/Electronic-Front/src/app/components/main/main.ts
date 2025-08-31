import { Component, inject, Input } from '@angular/core';
import { ProductoService } from '../../services/producto-service';
import { CategoriaService } from '../../services/categoria-service';
import { AddEditProducto } from './add-edit-producto/add-edit-producto';
import { AddEditCategoria } from './add-edit-categoria/add-edit-categoria';
import { DeleteElement } from './delete-element/delete-element';

@Component({
  selector: 'app-main',
  imports: [AddEditProducto, AddEditCategoria, DeleteElement],
  templateUrl: './main.html',
  styleUrl: '../../../styles/main/main.scss',
})
export class Main {
  @Input() receivedTableValue!: number;
  //
  productoService = inject(ProductoService);
  categoriaService = inject(CategoriaService);
  //
  productos: any[] = [];
  categorias: any[] = [];

  //
  constructor() {
    this.productoService.obtenerProductos().subscribe((datos) => {
      this.productos = datos;
    });

    this.categoriaService.obtenerCateogrias().subscribe((datos)=>{
      this.categorias = datos;
    })

  }
}
