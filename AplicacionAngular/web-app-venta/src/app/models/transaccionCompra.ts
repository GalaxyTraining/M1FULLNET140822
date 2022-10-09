import { EliminarProductListaDetalle } from "./eliminarProductListaDetalle";
import { ListaDetalleCompra } from "./listarDetalleCompra";

export class TransaccionCompra
{
   constructor(public id:number,public numeroDocumento:number,public razonSocial:string,public total:number,
    public detalleCompras:ListaDetalleCompra[],public eliminarDetalleCompra:EliminarProductListaDetalle[]
    ){}
}