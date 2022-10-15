import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { CompraService } from '../compra-list/compra.service';
import { DialogoConfirmacionComponent } from '../dialogo-confirmacion/dialogo-confirmacion.component';
import { EditProductListaDetalle } from '../models/editProductListaDetalle';
import { EliminarProductListaDetalle } from '../models/eliminarProductListaDetalle';
import { ListaDetalleCompra } from '../models/listarDetalleCompra';
import { Respuesta } from '../models/respuesta';
import { TransaccionCompra } from '../models/transaccionCompra';
export class MyErrorStateMatcher implements ErrorStateMatcher{
  isErrorState(control:FormControl | null,form:FormGroupDirective | NgForm | null):boolean
  {
    const isSubmitted=form && form.submitted;
    return !!(control && control.invalid &&(control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: 'app-registro-compra',
  templateUrl: './registro-compra.component.html',
  styleUrls: ['./registro-compra.component.css']
})
export class RegistroCompraComponent implements OnInit {
casesForm:FormGroup=new FormGroup({});
id:number=0;
numeroDocumento='';
total:number=0;
razonSocial='';
producto='';
precio:number=0;
cantidad:number=0;
totalDetalle:number=0;
matcher=new MyErrorStateMatcher();
listDetalleCompra:ListaDetalleCompra[]=[];
editProductListaDetalle:EditProductListaDetalle[]=[];
eliminarProductoDetalle:EliminarProductListaDetalle[]=[];
displayedColumns:string[]=['id','producto','precio','cantidad','total','borrar'];
flagEditar=false;
mensaje:string="";
isLoadingResults=false;
@ViewChild(MatTable) tabla1!: MatTable<ListaDetalleCompra>;
@ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
dataSource:any;
constructor(private router:Router,private route:ActivatedRoute,private api:CompraService,private formBuilder:FormBuilder,public dialogo:MatDialog) { }

  ngOnInit(): void {

    this.route.queryParams.subscribe(params => {
      this.id=params['id'];
        if(this.id!=undefined) {
          this.obtenerProductoPorId(this.id);
          this.flagEditar=true;
        }
    })
    this.casesForm=this.formBuilder.group({
      id:[0],
      numeroDocumento:[null,Validators.required],
      razonSocial:[null,Validators.required],
      producto:[null,Validators.required],
      precio:[null,Validators.required],
      cantidad:[null,Validators.required],
      idDetalleCompra:[null]
    })
  }
  obtenerProductoPorId(id:number) 
  {
     this.api.getCompraPorId(id).subscribe((data:EditProductListaDetalle[])=>{
       this.casesForm.setValue({
        numeroDocumento:data[0].numeroDocumento,
        razonSocial:data[0].razonSocial,
        producto:null,
        precio:null,
        cantidad:null,
        id:data[0].idCompra,
        idDetalleCompra:data[0].id
       })
       this.editProductListaDetalle=data;
       this.dataSource=new MatTableDataSource<EditProductListaDetalle>(this.editProductListaDetalle);
       this.dataSource.paginator=this.paginator;
       this.total=data[0].totalCompra;
     })
  }
  Agregar() 
  {
    let max=0;
      if(this.flagEditar)
      {
        
        for(let numero of this.editProductListaDetalle)
        {
          if(max<numero.ordenSecuencia)
            max=numero.ordenSecuencia;
        }
        this.totalDetalle=this.casesForm.value.precio*this.casesForm.value.cantidad;
        this.total=this.total+this.totalDetalle;
        let elementoCompra=new EditProductListaDetalle(0,this.id,max+1,this.casesForm.value.numeroDocumento,this.casesForm.value.razonSocial,0,this.casesForm.value.producto,this.casesForm.value.precio,this.casesForm.value.cantidad,this.casesForm.value.totalDetalle);
        this.editProductListaDetalle.push(elementoCompra);
        this.dataSource=new MatTableDataSource<EditProductListaDetalle>(this.editProductListaDetalle);
      }
      else
      {
        for(let numero of this.listDetalleCompra)
        {
          if(max<numero.ordenSecuencia)
            max=numero.ordenSecuencia;
        }
        this.totalDetalle=this.casesForm.value.precio*this.casesForm.value.cantidad;
        this.total=this.total+this.totalDetalle;
        let elementoCompra=new ListaDetalleCompra(max+1,this.casesForm.value.producto,this.casesForm.value.precio,this.casesForm.value.cantidad,this.totalDetalle);
        this.listDetalleCompra.push(elementoCompra);
        this.dataSource=new MatTableDataSource<ListaDetalleCompra>(this.listDetalleCompra);
      }

      this.dataSource.paginator=this.paginator;
  }
  borrarFila(indice:number,id:number) {

    if(confirm("Realmente quiere borrarlo?"))
    {
      if(this.flagEditar)
      {
        this.editProductListaDetalle=this.editProductListaDetalle.filter((i)=>i.ordenSecuencia!=indice);
        let totalSuma=0;
        for(let i=0;i<this.editProductListaDetalle.length;i++){
          this.editProductListaDetalle[i].ordenSecuencia=i+1;
          totalSuma=totalSuma+this.editProductListaDetalle[i].total;
        }
        this.total=totalSuma;
        this.dataSource=new MatTableDataSource<EditProductListaDetalle>(this.editProductListaDetalle);
        this.dataSource.paginator=this.paginator;
        let eliminarProductListaDetalle=new EliminarProductListaDetalle(id);
        this.eliminarProductoDetalle.push(eliminarProductListaDetalle);
      }
      else{
        this.listDetalleCompra=this.listDetalleCompra.filter((i)=>i.ordenSecuencia!=indice);
        let totalSuma=0;
        for(let i=0;i<this.listDetalleCompra.length;i++){
          this.listDetalleCompra[i].ordenSecuencia=i+1;
          totalSuma=totalSuma+this.listDetalleCompra[i].total;
        }
        this.total=totalSuma;
        this.dataSource=new MatTableDataSource<ListaDetalleCompra>(this.listDetalleCompra);
        this.dataSource.paginator=this.paginator;
      }
    }
  }
  
  guardar()
  {
    if(this.listDetalleCompra.length==0)
    {
      alert("El detalle de la compra debe tener registros")
      return;
    }
    this.dialogo
    .open(DialogoConfirmacionComponent, {
      data: `¿Estas Seguro de guardar la informacion de la compra?`
    })
    .afterClosed()
    .subscribe((confirmado: Boolean) => {
      if (confirmado) {
        let detalleCompra=new TransaccionCompra(this.casesForm.value.id,this.casesForm.value.numeroDocumento,this.casesForm.value.razonSocial, this.total,this.listDetalleCompra,this.eliminarProductoDetalle);
        this.api.SaveCompras(detalleCompra).subscribe({
          next:(res:Respuesta)=>{
           console.log(res);
            this.isLoadingResults=false;
            this.router.navigate(["/mfacade/facade/mcompra/compra"]);

            this.mensaje= "Se creo correctamente la compra";
          //   const dialogRef = this.dialogo.open(DialogAlertComponent, {
          //  width: '250px',
          //  data: {mensaje: this.mensaje}

          //   });
 
       
      
             
          },error:(e)=>{

            console.log(e);
          

  
     
  
          }
        })
      } else {
        console.log("No deseaste Guardar");
      }
    });
  }
  editar(){

  }
}


