import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/user-management/user.service';
import { StatementService } from '../statement.service';
import { Statement } from '../statement';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import { Router } from '@angular/router';

@Component({
  selector: 'app-statement-add',
  templateUrl: './statement-add.component.html',
  styleUrls: ['./statement-add.component.css']
})
export class StatementAddComponent implements OnInit {

  statement:Statement = {
    id: 0,
    title : "",
    startDate: null, 
    endDate: null, 
    openingBalance:0,
    emailAddress:null
  };

  constructor(
    private userService:UserService,
    private router:Router,
    private statementService:StatementService
  ) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {

    console.log('onSubmit:', form.valid)

    if (form.valid) {
      console.log("Whoop! Form is ready for launch.")
      this.statement.emailAddress = this.userService.securityObject.emailAddress;
      this.statementService.post(this.statement).subscribe(
        result => {
            console.log('success: ', result);
            this.router.navigate(['/statements']);
        },
        error => console.log('error: ', error),
      );
    } else {
      console.log("Whoops... Euston we have an invalid form :(")
    }
  }

  goBack() {
    this.router.navigate(['/statements']);
  }
}