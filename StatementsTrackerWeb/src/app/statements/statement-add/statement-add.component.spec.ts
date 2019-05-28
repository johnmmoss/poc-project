import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatementAddComponent } from './statement-add.component';

describe('StatementAddComponent', () => {
  let component: StatementAddComponent;
  let fixture: ComponentFixture<StatementAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatementAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatementAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
