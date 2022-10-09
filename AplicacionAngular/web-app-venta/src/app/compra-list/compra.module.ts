import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompraRoutingModule } from './compra-routing.module';
import { CompraListComponent } from './compra-list.component';


@NgModule({
  declarations: [
    CompraListComponent
  ],
  imports: [
    CommonModule,
    CompraRoutingModule
  ]
})
export class CompraModule { }
