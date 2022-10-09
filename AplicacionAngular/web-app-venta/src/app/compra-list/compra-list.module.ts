import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompraListRoutingModule } from './compra-list-routing.module';
import { CompraListComponent } from './compra-list.component';


@NgModule({
  declarations: [
    CompraListComponent
  ],
  imports: [
    CommonModule,
    CompraListRoutingModule
  ]
})
export class CompraListModule { }
