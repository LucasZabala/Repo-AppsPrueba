import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IProducto } from '../../../interfaces/producto';
import { ICategoria } from '../../../interfaces/categoria';

@Component({
  selector: 'app-add-edit-producto',
  imports: [],
  templateUrl: './add-edit-producto.html',
  styleUrl: '../../../../styles/main/addEdit-Producto.scss',
})
export class AddEditProducto {
  @Input() reciveValueAddEditForm!: number;
  @Input() reciveProducto!: IProducto;
  @Input() reciveCategorias!: ICategoria[];

  @Output() formAddEditClosed = new EventEmitter();
  public onCancelClick(): void {
    this.formAddEditClosed.emit();
  }
}
