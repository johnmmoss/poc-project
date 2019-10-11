import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Statement } from '../statement';
import { UserService } from 'src/app/user-management/user.service';
import { StatementService } from '../statement.service';

@Component({
  selector: 'app-statement-list',
  templateUrl: './statement-list.component.html',
  styleUrls: ['./statement-list.component.css']
})
export class StatementListComponent implements OnInit {

  emailAddress:string;
  statements:Statement[] = [];

  constructor(
    private userService:UserService,
    private statementService:StatementService,
    private router:Router
  ) { }

  ngOnInit() {
    this.emailAddress = this.userService.securityObject.emailAddress;
    this.statementService.getAll(this.emailAddress).subscribe(
      response => {
        this.statements = response;
        console.log(this.statements);
      },
      error => console.log(error)
    );
  }

  showAddStatement() {
    this.router.navigate(['/statements/add']);
  }

  editStatement(statement:Statement) {
    this.router.navigate(['/statements/'+ statement.id +'/edit']);
  }
}