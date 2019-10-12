import { Component, OnInit } from '@angular/core';
import { Payment } from '../../payments/payment';
import { StatementService } from '../statement.service';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Statement } from '../statement';

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

  onSubmit(form: NgForm) {
    console.log('onSubmit:', form.valid)

    //this.statementService.post(.payment).subscribe(
    //  result => console.log('success: ', result),
    //  error => console.log('error: ', error),
    //);
  }

  goBack() {
    this.router.navigate(['/statements']);
  }
}
