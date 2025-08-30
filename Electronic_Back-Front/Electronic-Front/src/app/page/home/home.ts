import { Component } from '@angular/core';
import { Header } from '../../components/header/header';
import { Main } from '../../components/main/main';

@Component({
  selector: 'app-home',
  imports: [Main, Header],
  templateUrl: './home.html',
  styleUrl: '../../../styles/page/home.scss',
})
export class Home {
  valorTableSelect: number = 0;
  
  onTableSelectUpdate(valor: number) {
    this.valorTableSelect = valor;
  }
}
