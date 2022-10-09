import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FacadeRoutingModule } from './facade-routing.module';
import { FacadeComponent } from '../facade/facade.component';
import { MenuComponent } from './menu/menu.component';
//import { FooterComponent } from '../facade/footer/footer.component';


@NgModule({
  declarations: [FacadeComponent, MenuComponent],
  imports: [
    CommonModule,
    FacadeRoutingModule
  ]
})
export class FacadeModule { }