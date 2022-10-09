import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/usuario';
import {catchError,tap} from 'rxjs/operators';

const httpOptions={
  headers:new HttpHeaders({
    'Content-Type':'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }
  private readonly API_URL=environment.webAPI;
  public ValidarUsuario(usuario:Usuario):Observable<Usuario>{
    return this.http.post<Usuario>(this.API_URL+"Security/ValidateUser",usuario,httpOptions).pipe(tap((data)=>{
      console.log(JSON.stringify(data));
    }),catchError(err=>{throw console.log("Error del servidor detalles"+JSON.stringify(err))}))
  }
}
