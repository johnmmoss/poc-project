import { Injectable } from '@angular/core';
import { Statement } from './statement';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StatementService {

  constructor(private httpClient:HttpClient) { }

  post(statement:Statement) : Observable<any> {

    let url = 'http://localhost/StatementsTracker.api/api/statements';

    return this.httpClient.post(url, statement);
  }

  getAll(emailAddress:string) : Observable<any> {

    let url = `http://localhost/StatementsTracker.api/api/statements/${emailAddress}`

    return this.httpClient.get(url);
  }
}
