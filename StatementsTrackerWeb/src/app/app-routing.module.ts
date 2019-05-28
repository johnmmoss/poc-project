import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './user-management/login/login.component';
import { StatementEditComponent } from './statements/statement-edit/statement-edit.component';
import { HomePageComponent } from './shared/home-page/home-page.component';
import { AboutComponent } from './shared/about/about.component';
import { ContactComponent } from './shared/contact/contact.component';
import { StatementListComponent } from './statements/statement-list/statement-list.component';
import { StatementAddComponent } from './statements/statement-add/statement-add.component';

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "statements", component: StatementListComponent  },
  {path: "statements/add", component: StatementAddComponent  },
  //{path: "statements/{0}/edit", component: StatementListComponent  },
  //{path: "statements/{0}/payments", component: PaymentListComponent  },
  //{path: "statements/{0}/payments/add", component: PaymentAddComponent  },
  //{path: "statements/{0}/payments/{0}/edit", component: PaymentEditComponent  },
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
