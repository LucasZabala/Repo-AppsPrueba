import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { IProducto } from '../interfaces/producto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  private http = inject(HttpClient);
  private URLbase = environment.apiURL + '/api/Productoes';

  //Obtener
  public obtenerProductos(): Observable<IProducto[]> {
    return this.http.get<IProducto[]>(this.URLbase);
  }
  
  public obtenerProductoID(id:number): Observable<IProducto> {
    return this.http.get<IProducto>(this.URLbase + "/" + id);
  }

  //Agregar
  public agregarProducto(producto: IProducto): Observable<IProducto> {
    return this.http.post<IProducto>(this.URLbase, producto);
  }

  //Editar
     public editarProducto(producto: IProducto): Observable<IProducto> {
      return this.http.put<IProducto>(this.URLbase + "/" + producto.id, producto);
    }

  //Eliminar
  public deleteProducto(id:number):Observable<IProducto>{
    return this.http.delete<IProducto>(this.URLbase + "/" + id);
  }
}
