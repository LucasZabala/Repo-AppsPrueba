import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { IDeleteForm } from '../../../interfaces/delete-form';
import { ProductoService } from '../../../services/producto-service';
import { CategoriaService } from '../../../services/categoria-service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-delete-element',
  imports: [],
  templateUrl: './delete-element.html',
  styleUrl: '../../../../styles/main/delete-Element.scss',
})
export class DeleteElement {
  @Input() reciveOpenFormDelete!: IDeleteForm;

  @Output() formDeleteClosed = new EventEmitter();
    public onCancelClick(valor : number): void {
      this.formDeleteClosed.emit(valor);
    }

    productoService = inject(ProductoService);
    categoriaService = inject(CategoriaService);
    onEliminarElement(value: number, id:number){
      if(value == 1){
        this.productoService.deleteProducto(id).subscribe({
          next:()=>{
            console.log("Se elimino el producto");
            this.onCancelClick(3);
          },
          error(error:HttpErrorResponse){
            alert("No se pudo eliminar producto");
            console.log('Error al eliminar producto: ' + error)
          }
        })
      }
      //Eliminar Categoria
      if(value == 2){
        this.categoriaService.deleteCateogria(id).subscribe({
        next:() =>{
          console.log(`Se elimino la categoria`);
          this.onCancelClick(3);
        },
        error(error:HttpErrorResponse){
          alert(error.error);
          console.log('Error al eliminar la categoría. Inténtalo de nuevo.', error);
        }
      });
      }
    }

}
