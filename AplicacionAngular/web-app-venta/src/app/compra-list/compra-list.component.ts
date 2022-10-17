import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DialogAlertComponent } from '../dialog-alert/dialog-alert.component';
import { DialogoConfirmacionComponent } from '../dialogo-confirmacion/dialogo-confirmacion.component';
import { Compra } from '../models/compra';
import { ParametroBusqueda } from '../models/ParametroBusqueda';
import { Respuesta } from '../models/respuesta';
import { CompraService } from './compra.service';

@Component({
  selector: 'app-compra-list',
  templateUrl: './compra-list.component.html',
  styleUrls: ['./compra-list.component.css']
})
export class CompraListComponent implements OnInit {

  displayedColumns:string[]=['id','numeroDocumento','razonSocial','total','editar','borrar'];
  data:Compra[]=[];
  isLoadingResults=true;
  dataSource:any;
  mensaje:string="";
  casesForm:FormGroup=new FormGroup({});
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(private api:CompraService,public dialogo:MatDialog,private formBuilder:FormBuilder ) { }

  ngOnInit(): void {
    this.listarCompra('','');
    this.casesForm=this.formBuilder.group({
      numeroDocumento:[''],
      razonSocial:['']
    })
  }
   listarCompra(numeroDocumento:string,razonSocial:string){
    let parametroBusqueda=new ParametroBusqueda(numeroDocumento,razonSocial);
       this.api.ListCompras(parametroBusqueda).subscribe({
        next:(res:Compra[])=>{
          console.log(res);
          this.data=res;
          this.isLoadingResults=false;
          this.dataSource=new MatTableDataSource<Compra>(this.data);
          this.dataSource.paginator=this.paginator;
        },error:(e)=>{
          console.log(String(e).split(" ")[1]);
          if(String(e).split(" ")[1]=="404")
          {
            this.isLoadingResults=false;
            this.data=[];
           this.dataSource=new MatTableDataSource<Compra>(this.data);
            this.dataSource.paginator=this.paginator;
          }
        }
       })
   }
   borrarFila(id:number){
    this.dialogo.open(DialogoConfirmacionComponent,{data: `¿Estas seguro de eliminar la informacion de la compra?`})
    .afterClosed().subscribe((confirmado: Boolean)=>{
      if(confirmado)
      {
        this.api.DeleteCompras(id).subscribe({
          next:(respuesta:Respuesta)=>{
            console.log(respuesta);
            this.mensaje="Se elimino correcatemente la compra";
           this.mensajeAlerta(this.mensaje);
           location.reload();
          },error:(error)=>{
            console.log(error);
          }
        })
      }
      else{
        console.log("cancelar");
      }
    })
   }

   mensajeAlerta(mensaje:string){
    this.mensaje=mensaje;
    const dialogRef=this.dialogo.open(DialogAlertComponent,{
      width:'250px',
      data:{mensaje:this.mensaje}
    })
    dialogRef.afterClosed().subscribe(result=>{
      console.log('The dialog was closed');
    })
   }
   buscar()
   {
     this.listarCompra(this.casesForm.value.numeroDocumento,this.casesForm.value.razonSocial);
   }
   limpiar()
   {
    this.casesForm.setValue({
      numeroDocumento:"",
      razonSocial:"",
     })
   }
}
