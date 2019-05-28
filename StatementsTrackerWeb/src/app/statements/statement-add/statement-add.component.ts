import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/user-management/user.service';
import { StatementService } from '../statement.service';
import { Statement } from '../statement';

@Component({
  selector: 'app-statement-add',
  templateUrl: './statement-add.component.html',
  styleUrls: ['./statement-add.component.css']
})
export class StatementAddComponent implements OnInit {

  statement:Statement = {
    title : "",
    startDate: null, 
    endDate: null, 
    openingBalance:null,
    emailAddress:null
  };

  constructor(
    private userService:UserService,
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
        result => console.log('success: ', result),
        error => console.log('error: ', error),
      );
    } else {
      console.log("Whoops... Euston we have an invalid form :(")
    }
  }
}