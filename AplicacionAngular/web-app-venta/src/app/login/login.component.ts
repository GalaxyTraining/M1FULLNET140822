import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Usuario } from '../models/usuario';
import { Constants } from '../utils/constants';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router:Router,private loginService:LoginService) { }
  public usuario:string='';
  public clave:string='';
  public mensaje:string='';
  public isError=false;
  ngOnInit(): void {
  }
  logIn(formLogin:NgForm)
  {
      if(formLogin.valid) 
      {
        event?.preventDefault();
        let usu=new Usuario(this.usuario,this.clave,'');
        this.loginService.ValidarUsuario(usu).subscribe({
        next:(usuario:Usuario)=>{
           sessionStorage.removeItem("token");
           sessionStorage.setItem("token",usuario.token);
            this.router.navigate(["mfacade/facade/minicio/inicio"]);
            this.isError=false;
        },error:(error)=>{
          this.isError=true;
          this.mensaje=Constants.MENSAJE_ERROR.LOGIN.DATOS_ERRONEOS;
          console.log(error);
          setTimeout(()=>{this.isError=false;},4000);
        }
        })
      }
      else{
        this.isError=true;
        this.mensaje=Constants.MENSAJE_ERROR.LOGIN.CREDENCIALES;
        setTimeout(()=>{this.isError=false;},4000);
      }
  }
}
