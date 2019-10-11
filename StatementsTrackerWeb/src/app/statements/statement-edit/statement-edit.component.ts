import { Component, OnInit } from '@angular/core';
import { Payment } from '../../payments/payment';
import { StatementService } from '../statement.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-statement-edit',
  templateUrl: './statement-edit.component.html',
  styleUrls: ['./statement-edit.component.css']
})
export class StatementEditComponent implements OnInit {

  constructor(private statementService:StatementService) { }
  
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
  }

  onSubmit(form: NgForm) {
    console.log('onSubmit:', form.valid)

    //this.statementService.post(.payment).subscribe(
    //  result => console.log('success: ', result),
    //  error => console.log('error: ', error),
    //);
  }
}
