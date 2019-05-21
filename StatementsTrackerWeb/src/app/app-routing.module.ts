import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './user-management/login/login.component';
import { StatementEditComponent } from './statements/statement-edit/statement-edit.component';
import { HomePageComponent } from './shared/home-page/home-page.component';
import { AboutComponent } from './shared/about/about.component';
import { ContactComponent } from './shared/contact/contact.component';

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "statements", component: StatementEditComponent  },
  {path: "about", component: AboutComponent},
  {path: "contact", component: ContactComponent},
  {path: "home", component: HomePageComponent},
  {path: "**", component: HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
