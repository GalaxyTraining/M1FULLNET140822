import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Productos } from '../models/productos';
import { Observable } from 'rxjs';
import {catchError,tap} from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  private readonly API_URL=environment.webAPI;
     ListProductos():Observable<Productos[]>{
        return this.http.get<Productos[]>(this.API_URL+"Product/List").pipe(tap((data)=>{
          console.log(JSON.stringify(data));
        }),catchError(err=>{throw console.log('Error  del servidor detalles'+JSON.stringify(err));}))
     }
}
