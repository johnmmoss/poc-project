import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-statement-list',
  templateUrl: './statement-list.component.html',
  styleUrls: ['./statement-list.component.css']
})
export class StatementListComponent implements OnInit {

  constructor(
    private router:Router
  ) { }

  ngOnInit() {
  }

  showAddStatement() {
    this.router.navigate(['/statements/add']);
  }
}
