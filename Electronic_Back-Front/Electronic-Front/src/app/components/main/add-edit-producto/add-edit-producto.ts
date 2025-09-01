import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { IProducto } from '../../../interfaces/producto';
import { ICategoria } from '../../../interfaces/categoria';
import { FormsModule } from '@angular/forms';
import { ProductoService } from '../../../services/producto-service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-edit-producto',
  imports: [FormsModule],
  templateUrl: './add-edit-producto.html',
  styleUrl: '../../../../styles/main/addEdit-Producto.scss',
})
export class AddEditProducto {
  @Input() reciveValueAddEditForm!: number;
  @Input() reciveProducto!: IProducto;
  @Input() reciveCategorias!: ICategoria[];
  //Agragar Producto

  addProducto: IProducto = {
    nombre: '',
    descripcion: '',
    precio: 0,
    categoria_Id: 0
  };
  
  @Output() formAddEditClosed = new EventEmitter();
  public onCancelClick(valor: number): void {
    this.formAddEditClosed.emit(valor);
  }

  productoService = inject(ProductoService);
  //Add Producto
  onAddProducto() {
    if (this.addProducto.nombre.trim() == '' || this.addProducto.nombre.trim().length > 50) {
      alert('El nombre no debe estar vacio o tener mas de 50 caracteres');
      return;
    } else if (this.addProducto.descripcion.trim().length > 200) {
      alert('La descripcion no debe tener mas de 200 caracteres');
      return;
    } else if (this.addProducto.categoria_Id == 0) {
      alert('Debe seleccionar una categoria');
      return;
    } else {
      this.productoService.agregarProducto(this.addProducto).subscribe({
        next: (productoAgregado) => {
          console.log(
            `Se ha agregado el producto: ${productoAgregado.nombre} con ID: ${productoAgregado.id}`
          );
          this.onCancelClick(3);
        },
        error: (error: HttpErrorResponse) => {
          console.log('Error al agregar el producto. Inténtalo de nuevo.', error);
        },
      });
    }
  }

  //Editar Producto
  onEdditProdcuto(){
    if (this.reciveProducto.nombre.trim() == '' || this.reciveProducto.nombre.trim().length > 50) {
      alert('El nombre no debe estar vacio o tener mas de 50 caracteres');
      return;
    } else if (this.reciveProducto.descripcion.trim().length > 200) {
      alert('La descripcion no debe tener mas de 200 caracteres');
      return;
    } else if (this.reciveProducto.categoria_Id == 0) {
      alert('Debe seleccionar una categoria');
      return;
    } else {
      this.productoService.editarProducto(this.reciveProducto).subscribe({
        next:(productoEditado) =>{
          console.log(`Se edito el producto: ${productoEditado.nombre} con ID: ${productoEditado.id}`);
          this.onCancelClick(3);
        },
        error(error:HttpErrorResponse){
          console.log('Error al editar el producto. Inténtalo de nuevo.', error);
        }
      });
    }
  }
}
