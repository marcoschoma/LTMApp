import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './login/auth.guard';

import { routing } from './app.routing';

import { HTTP_INTERCEPTORS, HttpClient, HttpHandler } from '@angular/common/http';
import { TokenInterceptor } from './login/token.interceptor';
import { LoginService } from './login/login.service';
import { ProductService } from './product/product.service';
import { BaseService } from './base.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    routing,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    LoginService,
    HttpClient,
    ProductService,
    BaseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
