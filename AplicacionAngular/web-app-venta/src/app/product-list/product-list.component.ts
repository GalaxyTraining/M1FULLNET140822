import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { Productos } from '../models/productos';
import { ProductService } from './product.service';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  displayedColumns:string[]=['id','nombre','precio','tipo'];
  data:Productos[]=[];
  isLoadingResults=true;
  dataSource:any;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  constructor(private api:ProductService) { }

  ngOnInit(): void {
      this.api.ListProductos().subscribe({
        next:(res:Productos[])=>{
          this.data=res;
          this.isLoadingResults=false;
          this.dataSource=new MatTableDataSource<Productos>(this.data);
          this.dataSource.paginator=this.paginator;
        },error:(e)=>console.log(e)
      });

  }

}
