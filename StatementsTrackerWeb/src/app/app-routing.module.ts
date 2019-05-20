import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './user-management/login/login.component';
import { StatementEditComponent } from './statements/statement-edit/statement-edit.component';

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "statements", component: StatementEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
