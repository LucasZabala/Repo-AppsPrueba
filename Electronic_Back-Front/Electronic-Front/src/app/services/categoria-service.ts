import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { ICategoria } from '../interfaces/categoria';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoriaService {
  private http = inject(HttpClient);
  private URLbase = environment.apiURL + '/api/Categorias';

  public obtenerCateogrias(): Observable<ICategoria[]> {
    return this.http.get<ICategoria[]>(this.URLbase);
  }

  public obtenerCategoriaID(id: number): Observable<ICategoria> {
    return this.http.get<ICategoria>(this.URLbase + '/' + id);
  }
}
