import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from './layout/layout.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseUrlInterceptorInterceptor } from './core/Interceptors/base-url-interceptor.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    HttpClientModule

  ],
  providers: [
      { provide: "BASE_API_URL", useValue: environment.apiUrl },
      {provide: HTTP_INTERCEPTORS,useClass: BaseUrlInterceptorInterceptor,multi: true }
    ],
  bootstrap: [AppComponent],

})
export class AppModule { }
