import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { Productos } from '../models/productos';

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
  constructor() { }

  ngOnInit(): void {
  }

}
