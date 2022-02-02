import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRequestdetailComponent } from './add-requestdetail.component';

describe('AddRequestdetailComponent', () => {
  let component: AddRequestdetailComponent;
  let fixture: ComponentFixture<AddRequestdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRequestdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRequestdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
