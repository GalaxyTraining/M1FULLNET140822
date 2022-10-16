import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Compra } from '../models/compra';
import { ParametroBusqueda } from '../models/ParametroBusqueda';
import { CompraService } from './compra.service';

@Component({
  selector: 'app-compra-list',
  templateUrl: './compra-list.component.html',
  styleUrls: ['./compra-list.component.css']
})
export class CompraListComponent implements OnInit {

  displayedColumns:string[]=['id','numeroDocumento','razonSocial','total','editar'];
  data:Compra[]=[];
  isLoadingResults=true;
  dataSource:any;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(private api:CompraService ) { }

  ngOnInit(): void {
    this.listarCompra('','');
  }
   listarCompra(numeroDocumento:string,razonSocial:string){
    let parametroBusqueda=new ParametroBusqueda(numeroDocumento,razonSocial);
       this.api.ListCompras(parametroBusqueda).subscribe({
        next:(res:Compra[])=>{
          this.data=res;
          this.isLoadingResults=false;
          this.dataSource=new MatTableDataSource<Compra>(this.data);
          this.dataSource.paginator=this.paginator;
        },error:(e)=>{
          if(String(e.status).split(" ")[1]=="404")
          {
            this.isLoadingResults=false;
          }
        }
       })
   }
}
