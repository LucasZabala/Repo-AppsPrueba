import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { ICategoria } from '../../../interfaces/categoria';
import { CategoriaService } from '../../../services/categoria-service';
import { FormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-edit-categoria',
  imports: [FormsModule],
  templateUrl: './add-edit-categoria.html',
  styleUrl: '../../../../styles/main/addEdit-Categoria.scss',
})
export class AddEditCategoria {
  @Input() reciveValueAddEditForm!: number;
  @Input() reciveCategoria!: ICategoria;
  //Categoria para poder editar el nombre
  categoriaAdd: ICategoria = { nombre: '' };
  //Cerrar form
  @Output() formAddEditClosed = new EventEmitter();
  public onCancelClick(value: number): void {
    this.formAddEditClosed.emit(value);
  }

  categoriaService = inject(CategoriaService);
  //Agregar Cateogira
  onAddCategoraClick() {
    if (this.categoriaAdd.nombre.length === 0 || this.categoriaAdd.nombre.length > 50) {
      console.log('La categoría no debe estar vacía ni tener más de 50 caracteres.', 'Error');
      return;
    } else {
      this.categoriaService.agregarCategoria(this.categoriaAdd).subscribe({
        next: (categoriaAgregada) => {
          console.log(`Se ha agregado la categoria: ${categoriaAgregada.nombre} con ID: ${categoriaAgregada.id}`);
          this.onCancelClick(3);
        },
        error: (error: HttpErrorResponse) => {
          console.log('Error al agregar la categoría. Inténtalo de nuevo.', error);
        },
      });
    }
  }

  //Editar Categoria
  onEditCateoriaClick(){
    if (this.reciveCategoria.nombre.length === 0 || this.reciveCategoria.nombre.length > 50) {
      console.log('La categoría no debe estar vacía ni tener más de 50 caracteres.', 'Error');
      return;
    }else{
      this.categoriaService.editarCategoria(this.reciveCategoria).subscribe({
        next:(categoriaEditada) =>{
          console.log(`Se edito la categoria: ${categoriaEditada.nombre} con ID: ${categoriaEditada.id}`);
          this.onCancelClick(3);
        },
        error(error:HttpErrorResponse){
          console.log('Error al editar la categoría. Inténtalo de nuevo.', error);
        }
      });
    }
  }
}
