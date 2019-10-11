import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './user-management/login/login.component';
import { HomePageComponent } from './shared/home-page/home-page.component';
import { StatementListComponent } from './statements/statement-list/statement-list.component';
import { StatementAddComponent } from './statements/statement-add/statement-add.component';
import { StatementEditComponent } from './statements/statement-edit/statement-edit.component';
import { AuthGuard } from './shared/auth.guard';
import { UnauthorisedComponent } from './shared/unauthorised/unauthorised.component';

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {
    path: "statements", component: StatementListComponent,
    canActivate:[AuthGuard],
    data: {roleValue: "User"}
  },
  {
    path: "statements/add", component: StatementAddComponent,
    canActivate:[AuthGuard],
    data: {roleValue: "User"}
  },
  {path: "statements/:id/edit", component: StatementEditComponent},
  //{path: "statements/{0}/payments", component: PaymentListComponent  },
  //{path: "statements/{0}/payments/add", component: PaymentAddComponent  },
  //{path: "statements/{0}/payments/{0}/edit", component: PaymentEditComponent  },
  {path: "unauthorised", component: UnauthorisedComponent},
  {path: "home", component: HomePageComponent},
  {path: "**", component: HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
