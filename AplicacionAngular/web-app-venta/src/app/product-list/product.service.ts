import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Productos } from '../models/productos';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  private readonly API_URL=environment.webAPI;
    // ListProductos():Observable<Productos[]>{
      
    // }
}
