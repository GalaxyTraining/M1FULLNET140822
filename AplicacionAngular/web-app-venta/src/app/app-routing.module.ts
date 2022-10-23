import { Injectable, NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RouterModule, RouterStateSnapshot, Routes, TitleStrategy } from '@angular/router';
import { AutenticationGuardService } from './login/autentication-guard.service';

const routes: Routes = [{path:'',redirectTo:'mlogin',pathMatch:'full'},
{path:'mlogin',loadChildren:()=>import('./login/login.module').then(m=>m.LoginModule)},
{path:'mfacade',loadChildren:()=>import('./facade/facade.module').then(m=>m.FacadeModule),canActivate:[AutenticationGuardService]},
{ path: '**', redirectTo: 'mlogin' }
];

// @Injectable()
// export class TemplatePageTitleStrategy extends TitleStrategy {
//   constructor(private readonly title: Title) {
//     super();
//   }

//   override updateTitle(routerState: RouterStateSnapshot) {
//     const title = this.buildTitle(routerState);
//     if (title !== undefined) {
//       this.title.setTitle(`Aplicacion venta - ${title}`);
//     }
//   }
// }


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
 // providers: [{provide: TitleStrategy,  useClass: TemplatePageTitleStrategy}]
})
export class AppRoutingModule { }
