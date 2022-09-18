import {NgModule} from '@angular/core';
import {Routes,RouterModule} from '@angular/router';
import {FacadeComponent} from './facade.component';

const routes:Routes=[
    {path:'',redirectTo:'facade',pathMatch:'full'},
    {path:'facade',component:FacadeComponent,
 children:
    [
        {path:'',redirectTo:'mproduct',pathMatch:'full'},
        {path:'mproduct',loadChildren:()=>import('../product-list/product.module').then(m=>m.ProductModule)}
    ] 
}  
];
@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class FacadeRoutingModule{}