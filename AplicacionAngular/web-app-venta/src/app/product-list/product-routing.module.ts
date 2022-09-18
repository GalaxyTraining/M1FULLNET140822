import {NgModule} from '@angular/core';
import {Routes,RouterModule} from '@angular/router';
import { ProductListComponent } from './product-list.component';
const routes:Routes=[{path:'',redirectTo:'product',pathMatch:'full'},
{path:'product',component:ProductListComponent}];
@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class ProductRoutingModule{}