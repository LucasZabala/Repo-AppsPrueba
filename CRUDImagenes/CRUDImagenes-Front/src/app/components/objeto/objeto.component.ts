import { Component, inject } from '@angular/core';
import { ObjetoService } from '../../services/objeto.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IObjeto } from 'src/app/interfaces/objeto';

@Component({
  selector: 'app-objeto',
  templateUrl: './objeto.component.html',
  styleUrls: ['./objeto.component.scss'],
})
export class ObjetoComponent {
  objetoService = inject(ObjetoService);
  titulo: string = '';
  descripcion: string = '';
  selectedFile: File | null = null;
  selectedFileEdit: File | null = null;
  objetos: IObjeto[] = [];
  objetoEdit: IObjeto = {id:0, titulo:'', descripcion:'', urlImg:''};

  trackByIndex(index: number, item: any): number {
    return index;
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  //Agregar Objeto
  onSubmitAdd() {
    if (this.selectedFile) {
      this.objetoService
        .CreateObjeto(this.selectedFile, this.titulo, this.descripcion)
        .subscribe({
          next: () => {
            console.log(`Se agrego correctamente el objeto`);
          },
          error: (error: HttpErrorResponse) => {
            console.log(
              'Error al agregar la categoría. Inténtalo de nuevo.',
              error
            );
          },
        });
    }
  }

  //Editar Objeto
  onFileSelectedEdit(event: any) {
    this.selectedFileEdit = event.target.files[0];
  }

  onSubmitEdit() {
    if (this.objetoEdit && this.selectedFileEdit) {
      this.objetoService
        .UpdateObjeto(
          this.objetoEdit.id,
          this.selectedFileEdit,
          this.objetoEdit.titulo,
          this.objetoEdit.descripcion
        )
        .subscribe({
          next: () => {
            console.log(
              `Se edito correctamente el objeto con id ${this.objetoEdit?.id}`
            );
            this.obtenerDatos();
          },
          error: (error: HttpErrorResponse) => {
            console.log(
              'Error al editar el objeto. Inténtalo de nuevo.',
              error
            );
          },
        });
    }
  }
  //Eliminar objeto
  eliminarObjeto(id: number) {
    this.objetoService.DeleteObjeto(id).subscribe({
      next: () => {
        console.log(`Se elimino correctamente el objeto con id ${id}`);
        this.obtenerDatos();
      },
      error: (error: HttpErrorResponse) => {
        console.log('Error al eliminar el objeto. Inténtalo de nuevo.', error);
      },
    });
  }

  //Obtiene objetos
  obtenerDatos() {
    this.objetoService.GetAllObjetos().subscribe({
      next: (data: IObjeto[]) => {
        this.objetos = data;

        console.log(this.objetos);
      },
      error: (error: HttpErrorResponse) => {
        console.log('Error al obtener los objetos. Inténtalo de nuevo.', error);
      },
    });
  }

  //Obtener por ID
  obtenerPorId(id: number) {
    this.objetoService.GetObjetoById(id).subscribe({
      next: (data: IObjeto) => {
        this.objetoEdit = data;
      },
      error: (error: HttpErrorResponse) => {
        console.log('Error al obtener el objeto. Inténtalo de nuevo.', error);
      },
    });
  }
}
