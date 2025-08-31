import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
    private http = inject (HttpClient);
    private URLbase = environment.apiURL + "/api/Categorias";

    public obtenerCateogrias(){
      return this.http.get<any>(this.URLbase);
    }
}
