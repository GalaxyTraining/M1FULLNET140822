import { Injectable, NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RouterModule, RouterStateSnapshot, Routes, TitleStrategy } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';

const routes: Routes = [{path:'products',component:ProductListComponent,title: 'Producto Lista'}
,{path:'',redirectTo:'products',pathMatch:'full'}];

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
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [{provide: TitleStrategy,  useClass: TemplatePageTitleStrategy}]
})
export class AppRoutingModule { }
