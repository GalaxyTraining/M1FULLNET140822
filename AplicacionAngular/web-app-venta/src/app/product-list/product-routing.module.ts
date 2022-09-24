import {Injectable, NgModule} from '@angular/core';
import { Title } from '@angular/platform-browser';
import {Routes,RouterModule, TitleStrategy, RouterStateSnapshot} from '@angular/router';
import { ProductListComponent } from './product-list.component';
const routes:Routes=[{path:'',redirectTo:'product',pathMatch:'full'},
{path:'product',component:ProductListComponent,title: 'Producto Lista'}];


@Injectable()
export class TemplatePageTitleStrategy extends TitleStrategy {
  constructor(private readonly title: Title) {
    super();
  }

  override updateTitle(routerState: RouterStateSnapshot) {
    const title = this.buildTitle(routerState);
    if (title !== undefined) {
      this.title.setTitle(`Aplicacion venta - ${title}`);
    }
  }
}
@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule],
    providers: [{provide: TitleStrategy,  useClass: TemplatePageTitleStrategy}]
})
export class ProductRoutingModule{}