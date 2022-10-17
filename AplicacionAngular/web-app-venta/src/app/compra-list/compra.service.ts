import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Compra } from '../models/compra';
import {catchError,tap} from 'rxjs/operators';
import { TransaccionCompra } from '../models/transaccionCompra';
import { Respuesta } from '../models/respuesta';
import { EditProductListaDetalle } from '../models/editProductListaDetalle';
import { ParametroBusqueda } from '../models/ParametroBusqueda';
const httpOptions={
  headers:new HttpHeaders({
    'Content-Type':'application/json',
    'Authorization':'Bearer '+sessionStorage.getItem("token")
  })
}
@Injectable({
  providedIn: 'root'
})
export class CompraService {

  constructor(private http:HttpClient) { }
  private readonly API_URL=environment.webAPI;
   ListCompras(parametro:ParametroBusqueda):Observable<Compra[]>{
     return this.http.post<Compra[]>(this.API_URL+"Compra/List",parametro,httpOptions).pipe(tap((data)=>{
         console.log(JSON.stringify(data));
     }),catchError(err=>{throw new Error(JSON.stringify(err.status))}))
   }
   SaveCompras(transaccionCompra:TransaccionCompra):Observable<Respuesta>{

     return this.http.post<Respuesta>(this.API_URL+"Compra/Save",transaccionCompra,httpOptions).pipe(tap((data)=>{
          console.log(data);
     }),catchError(err=>{throw console.log(err)}));
   }
   getCompraPorId(id:number):Observable<EditProductListaDetalle[]>{
     return this.http.get<EditProductListaDetalle[]>(this.API_URL+"Compra/Detail/"+id,httpOptions).pipe(tap((data)=>{
      console.log(data);
       }),catchError(err=>{throw console.log(err)}));
    }
  EditCompras(transaccionCompra:TransaccionCompra):Observable<Respuesta>{
    return this.http.put<Respuesta>(this.API_URL+"Compra/Update",transaccionCompra,httpOptions).pipe(tap((data)=>{
      console.log(data);
 }),catchError(err=>{throw console.log(err)}));
  }
  DeleteCompras(id:number):Observable<Respuesta>{
     return this.http.delete<Respuesta>(this.API_URL+"Compra/Delete/"+id,httpOptions).pipe(tap((data)=>{
        console.log(data);
     }),catchError(err=>{throw console.log(err)}));
  }
 }

