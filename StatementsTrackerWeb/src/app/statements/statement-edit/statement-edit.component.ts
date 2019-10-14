import { Component, OnInit } from '@angular/core';
import { Payment } from '../../payments/payment';
import { StatementService } from '../statement.service';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Statement } from '../statement';
import { UserService } from 'src/app/user-management/user.service';

@Component({
  selector: 'app-statement-edit',
  templateUrl: './statement-edit.component.html',
  styleUrls: ['./statement-edit.component.css']
})
export class StatementEditComponent implements OnInit {

  id:number;
  statement:Statement = {
    id: 0,
    title : "",
    startDate: null, 
    endDate: null, 
    openingBalance:null,
    emailAddress:null
  };

  constructor(private statementService:StatementService,
              private userService:UserService,
              private router:Router,
              private route:ActivatedRoute
  ){}
  
  originalPayment:Payment = {
    description:"Lakes Holiday",
    amount:"300",
    debitOrCredit:"debit",
    isMonthlyPayment:"true",
    paymentMethod:"Debit Card"
  };

  //payment:Payment = { ...this.orginalPayment };   // Did not work???
  //payment:Payment = Object.assign({}, this.originalPayment);

  payment:Payment = {
    description:null,
    amount:null,
    debitOrCredit:null,
    isMonthlyPayment:null,
    paymentMethod:null
  };
  
  ngOnInit() {
    console.log("Loading edit statements screen...")
    this.id = +this.route.snapshot.paramMap.get('id');
    console.log("Found Id: " + this.id);
    this.statementService.get(this.id)
    .subscribe(
      response => {
        console.log(response);
        this.statement = response;
        this.statement.startDate = new Date(response.startDate);
        this.statement.endDate = new Date(response.endDate);
      },
      (err:any) => console.log("Error: "+ err)
    )
  }

  goBack() {
    this.router.navigate(['/statements']);
  }

  onSubmit(form: NgForm) {

      console.log('onSubmit:', form.valid)

      if (form.valid) {
          console.log("Whoop! Form is ready for launch.")
          this.statement.emailAddress = this.userService.securityObject.emailAddress;
          this.statementService.update(this.statement).subscribe(
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
}
