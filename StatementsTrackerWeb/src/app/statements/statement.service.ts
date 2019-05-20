import { Injectable } from '@angular/core';
import { Payment } from './payment';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StatementService {

  constructor(private httpClient:HttpClient) { }

  post(payment:Payment) : Observable<any> {

    let url = 'http://localhost/StatementsTracker/api/statement';

    return this.httpClient.post(url, payment);
  }
}
