import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICategoria } from '../../../interfaces/categoria';

@Component({
  selector: 'app-add-edit-categoria',
  imports: [],
  templateUrl: './add-edit-categoria.html',
  styleUrl: '../../../../styles/main/addEdit-Categoria.scss',
})
export class AddEditCategoria {
  @Input() reciveValueAddEditForm!: number;
  @Input() reciveCategoria!: ICategoria;

  @Output() formAddEditClosed = new EventEmitter();
  public onCancelClick(): void {
    this.formAddEditClosed.emit();
  }

}
