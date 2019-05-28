import { Component, OnInit } from '@angular/core';
import { Payment } from '../payment';

@Component({
  selector: 'app-payment-list',
  templateUrl: './payment-list.component.html',
  styleUrls: ['./payment-list.component.css']
})
export class PaymentListComponent implements OnInit {
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
  
  constructor() { }

  ngOnInit() {
  }

}
