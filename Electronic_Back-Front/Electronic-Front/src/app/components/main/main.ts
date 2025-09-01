import { Component, inject, Input } from '@angular/core';
import { ProductoService } from '../../services/producto-service';
import { CategoriaService } from '../../services/categoria-service';
import { AddEditProducto } from './add-edit-producto/add-edit-producto';
import { AddEditCategoria } from './add-edit-categoria/add-edit-categoria';
import { DeleteElement } from './delete-element/delete-element';
import { IProducto } from '../../interfaces/producto';
import { ICategoria } from '../../interfaces/categoria';
import { IDeleteForm } from '../../interfaces/delete-form';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [AddEditProducto, AddEditCategoria, DeleteElement],
  templateUrl: './main.html',
  styleUrl: '../../../styles/main/main.scss',
})
export class Main {
  //----------Cambiar de tablas
  @Input() receivedTableValue!: number;
  //----------Open forms acciones
  //Add Form Producto-Cateogria
  openFormAddEditProducto: number = 0;
  openFormAddEditCategoria: number = 0;
  //Delete Form Producto-Cateogria
  openFormDelete: IDeleteForm = { valor: 0, id: 0 };
  //Producto y Categoria
  producto!: IProducto;
  categoria!: ICategoria;

  //Open Close Form Add Producto
  openClosedFormAddEditProducto(valor: number, productoId: number) {
    //Obtiene producto para editarlo
    if (valor == 2) {
      this.productoService.obtenerProductoID(productoId).subscribe({
        next: (producto: IProducto) => {
          this.producto = producto;
          console.log('Producto obtenido para editar:', this.producto);
        },
        error: (error: any) => {
          console.error('Error al obtener el producto:', error);
        },
      });
    }

    if (valor == 3) {
      this.obtenerProductos();
      alert("asasa");
      this.openFormAddEditProducto = 0;
      return;
    }
    this.openFormAddEditProducto = valor;

  }

  //Open Close Form Add Categoria
  openClosedFormAddEditCategoria(valor: number, categoriaId: number) {
    //Obtiene Categoria para editarla
    if (valor == 2) {
      this.categoriaService.obtenerCategoriaID(categoriaId).subscribe({
        next: (categoria: ICategoria) => {
          this.categoria = categoria;
          console.log('Categoria obtenido para editar:', this.categoria);
        },
        error: (error: any) => {
          console.error('Error al obtener el categoria:', error);
        },
      });
    }
    //Refrezca tabla categoria
    if (valor == 3) {
      this.obtenerCategorias();
      this.obtenerProductos();
      this.openFormAddEditCategoria = 0;
      return;
    }

    this.openFormAddEditCategoria = valor;

  }

  //Delete Form Producto-Cateogria
  openClosedFormDelete(valor1: number, valor2: number) {
    if(valor1 == 3){
      this.obtenerProductos();
      this.obtenerCategorias();
      this.openFormDelete = { valor: 0, id: 0 };
    }
    this.openFormDelete = { valor: valor1, id: valor2 };
  }

  //Inyeccion de datos Productos y categoria
  productoService = inject(ProductoService);
  categoriaService = inject(CategoriaService);
  //Variables para obtener productos y categorias
  productos: IProducto[] = [];
  categorias: ICategoria[] = [];
  //
  constructor() {
    this.obtenerProductos();
    this.obtenerCategorias();
  }

  //OBTENER
  obtenerProductos(): void {
    this.productoService.obtenerProductos().subscribe((datos) => {
      this.productos = datos;
    });
  }

  obtenerCategorias(): void {
    this.categoriaService.obtenerCateogrias().subscribe((datos) => {
      this.categorias = datos;
    });
  }
}
