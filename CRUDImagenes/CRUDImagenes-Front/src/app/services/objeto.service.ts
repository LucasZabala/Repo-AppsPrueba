import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { IObjeto } from '../interfaces/objeto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ObjetoService {
  private http = inject(HttpClient);
  private URLObject = environment.apiURL + '/api/Objetoes';
  private URLImgs = environment.apiURL + '/api/Image';

  //Obtener todos los objetos
  public GetAllObjetos(): Observable<IObjeto[]> {
    return this.http.get<IObjeto[]>(this.URLObject);
  }

  //Obtener Objetos por Id
  public GetObjetoById(id: number): Observable<IObjeto> {
    return this.http.get<IObjeto>(`${this.URLObject}/${id}`);
  }

  //Obtener imagen
  public GetImageByURL(urlImg: string): Observable<File> {
    return this.http.get<File>(`${this.URLImgs}/uploads/${urlImg}`);
  }

  //Crear un nuevo objeto
  public CreateObjeto(
    file: File,
    titulo: string,
    descripcion: string
  ): Observable<any> {
    const formData = new FormData();

    formData.append('file', file);
    formData.append('titulo', titulo);
    formData.append('descripcion', descripcion);

    return this.http.post<any>(`${this.URLImgs}/upload`, formData);
  }

  //EDITAR OBJETO
  public UpdateObjeto(id: number, newFile: File, titulo: string, descripcion: string): Observable<any> {
    const formData = new FormData();
    formData.append('newFile', newFile);
    formData.append('titulo', titulo);
    formData.append('descripcion', descripcion);

    return this.http.put<any>(`${this.URLImgs}/edit/${id}`, formData);
  }

  //ELIMINAR OBJETO
  public DeleteObjeto(id: number): Observable<any> {
    return this.http.delete<any>(`${this.URLImgs}/delete/${id}`);
  }
}
