import { Component, inject, Input } from '@angular/core';
import { ProductoService } from '../../services/producto-service';
import { CategoriaService } from '../../services/categoria-service';
import { AddEditProducto } from './add-edit-producto/add-edit-producto';
import { AddEditCategoria } from './add-edit-categoria/add-edit-categoria';
import { DeleteElement } from './delete-element/delete-element';
import { IProducto } from '../../interfaces/producto';
import { ICategoria } from '../../interfaces/categoria';

@Component({
  selector: 'app-main',
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
  openFormDeleteProducto: boolean = false;
  openFormDeleteCategoria: boolean = false;
  //Producto y Categoria
  producto!: IProducto;
  categoria!: ICategoria;
  //Add Edit Form Producto-Cateogria
  openClosedFormAddEditProducto(valor: number, productoId: number) {
    this.openFormAddEditProducto = valor;
    if (valor == 2) {
      this.productoService.obtenerProductoID(productoId).subscribe({
        next: (producto: IProducto) => {
          this.producto = producto;
          console.log('Producto obtenido para editar:', this.producto);
        },
        error: (error: any) => {
          console.error('Error al obtener el producto:', error);
        },
        complete: () => {
          console.log('La operación de obtención del producto ha finalizado.');
        },
      });
    }
  }
  openClosedFormAddEditCategoria(valor: number, categoriaId: number) {
    this.openFormAddEditCategoria = valor;
    if (valor == 2) {
      this.categoriaService.obtenerCategoriaID(categoriaId).subscribe({
        next: (categoria: ICategoria) => {
          this.categoria = categoria;
          console.log('Categoria obtenido para editar:', this.categoria);
        },
        error: (error: any) => {
          console.error('Error al obtener el categoria:', error);
        },
        complete: () => {
          console.log('La operación de obtención del categoria ha finalizado.');
        },
      });
    }
  }

  //Delete Form Producto-Cateogria
  openClosedFormDeleteProducto(valor: boolean) {
    this.openFormDeleteProducto = valor;
  }
  openClosedFormDeleteCategoria(valor: boolean) {
    this.openFormDeleteCategoria = valor;
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

  //AGREGAR
  addProducto(producto: IProducto): void {
    this.productoService.agregarProducto(producto);
  }
}
