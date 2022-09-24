import {NgModule} from '@angular/core';
import {Routes,RouterModule} from '@angular/router';
import {InicioComponent} from './inicio.component';

const routes:Routes=[
  {path:'',redirectTo:'inicio',pathMatch:'full'},
  {path:'inicio',component:InicioComponent}
];
@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class InicioRoutingModule{
    
}
