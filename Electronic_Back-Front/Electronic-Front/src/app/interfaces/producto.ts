import { ICategoria } from "./categoria";

export interface IProducto {
    id?:number;
    nombre: string;
    descripcion?: string;
    precio: number;
    categoria_Id: number;
    categoria: ICategoria;
}
