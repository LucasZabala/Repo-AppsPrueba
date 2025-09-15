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
  objetos: IObjeto[] = [];
  imagen: string = '';

trackByIndex(index: number, item: any): number {
    return index;
  }
  
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  onSubmit() {
    if (this.selectedFile) {
      this.objetoService.CreateObjeto(this.selectedFile, this.titulo, this.descripcion).subscribe({
        next: () => {
          console.log(`Se agrego correctamente el objeto`);
        },
        error: (error: HttpErrorResponse) => {
          console.log('Error al agregar la categoría. Inténtalo de nuevo.', error);
        },
      });
    }
  }

  obtenerDatos(){
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
  
}
