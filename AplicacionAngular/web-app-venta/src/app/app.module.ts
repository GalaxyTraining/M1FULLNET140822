import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductService } from './product-list/product.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DialogoConfirmacionComponent } from './dialogo-confirmacion/dialogo-confirmacion.component';
import { DialogAlertComponent } from './dialog-alert/dialog-alert.component';
import { MatDialogModule } from '@angular/material/dialog';
import { InterceptorService } from './interceptors/interceptor.service';
import { AutenticationGuardService } from './login/autentication-guard.service';
@NgModule({
  declarations: [
    AppComponent,
    DialogoConfirmacionComponent,
    DialogAlertComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule
  ],
  providers: [ProductService,{
    provide:HTTP_INTERCEPTORS, useClass:InterceptorService,
    multi:true,
  },AutenticationGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
