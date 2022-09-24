import {NgModule} from '@angular/core';
import {Routes,RouterModule, TitleStrategy} from '@angular/router';
import { TemplatePageTitleStrategy } from '../product-list/product-routing.module';
import {FacadeComponent} from './facade.component';

const routes:Routes=[
    {path:'',redirectTo:'facade',pathMatch:'full'},
    {path:'facade',component:FacadeComponent,
 children:
    [
        {path:'',redirectTo:'minicio',pathMatch:'full'},
        {path:'minicio',loadChildren:()=>import('../inicio/inicio.module').then(m=>m.InicioModule)},
        {path:'mproduct',loadChildren:()=>import('../product-list/product.module').then(m=>m.ProductModule)}
    ] 
}  
];
@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class FacadeRoutingModule{}