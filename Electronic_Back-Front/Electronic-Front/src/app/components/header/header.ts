import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: '../../../styles/header/header.scss'
})
export class Header {

  
  @Output() updateTableSelect = new EventEmitter<number>();
  tableUpdate(num : number) {
    // Emite un nuevo valor a través del EventEmitter
    this.updateTableSelect.emit(num);
  }
  @Input() receivedTableValue!: number;
}
