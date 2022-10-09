import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Productos } from '../models/productos';
import { Observable } from 'rxjs';
import {catchError,tap} from 'rxjs/operators';
const httpOptions={
  headers:new HttpHeaders({
    'Content-Type':'application/json',
    'Authorization':'Bearer '+sessionStorage.getItem("token")
  })
}
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  private readonly API_URL=environment.webAPI;
     ListProductos():Observable<Productos[]>{
        return this.http.get<Productos[]>(this.API_URL+"Product/List",httpOptions).pipe(tap((data)=>{
          console.log(JSON.stringify(data));
        }),catchError(err=>{throw console.log('Error  del servidor detalles'+JSON.stringify(err));}))
     }
}
