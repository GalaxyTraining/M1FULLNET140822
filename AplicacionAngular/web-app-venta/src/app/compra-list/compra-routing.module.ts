import { Injectable, NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RouterModule, RouterStateSnapshot, Routes, TitleStrategy } from '@angular/router';
import { RegistroCompraComponent } from '../registro-compra/registro-compra.component';
import { CompraListComponent } from './compra-list.component';

const routes: Routes = [{path:'',redirectTo:'compra',pathMatch:'full'},
{path:'compra',component:CompraListComponent,title: 'Compra Lista'},{path:'registroCompra',component:RegistroCompraComponent,title: 'Registro Compra'}];

@Injectable()
export class TemplatePageTitleStrategy extends TitleStrategy {
  constructor(private readonly title: Title) {
    super();
  }

  override updateTitle(routerState: RouterStateSnapshot) {
    const title = this.buildTitle(routerState);
    if (title !== undefined) {
      this.title.setTitle(`Aplicacion Compra - ${title}`);
    }
  }
}
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompraRoutingModule { }
