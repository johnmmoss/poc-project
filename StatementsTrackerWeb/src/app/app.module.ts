import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StatementEditComponent } from './statements/statement-edit/statement-edit.component';
import { LoginComponent } from './user-management/login/login.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { HomePageComponent } from './shared/home-page/home-page.component';
import { UserService } from './user-management/user.service';
import { StatementAddComponent } from './statements/statement-add/statement-add.component';
import { PaymentAddComponent } from './payments/payment-add/payment-add.component';
import { PaymentListComponent } from './payments/payment-list/payment-list.component';
import { StatementListComponent } from './statements/statement-list/statement-list.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { UnauthorisedComponent } from './shared/unauthorised/unauthorised.component';
import { JwtInterceptorModule } from './shared/http-interceptor';
import { HasRoleDirective } from './shared/has-role.directive';
import { TitleRowComponent } from './shared/components/title-row/title-row.component';
import {KeyFilterModule} from 'primeng/keyfilter';

@NgModule({
  declarations: [
    AppComponent,
    StatementEditComponent,
    LoginComponent,
    HomePageComponent,
    StatementAddComponent,
    PaymentAddComponent,
    PaymentListComponent,
    StatementListComponent,
    UnauthorisedComponent,
    HasRoleDirective,
    TitleRowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    AngularFontAwesomeModule,
    HttpClientModule,
    JwtInterceptorModule,
    KeyFilterModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
