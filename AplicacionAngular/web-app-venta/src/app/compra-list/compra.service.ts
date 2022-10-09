import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Compra } from '../models/compra';
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
export class CompraService {

  constructor(private http:HttpClient) { }
  private readonly API_URL=environment.webAPI;
   ListCompras():Observable<Compra[]>{
     return this.http.get<Compra[]>(this.API_URL+"Compra/List",httpOptions).pipe(tap((data)=>{
         console.log(JSON.stringify(data));
     }),catchError(err=>{throw new Error(err)}))
   }
  // SaveCompras()
}
