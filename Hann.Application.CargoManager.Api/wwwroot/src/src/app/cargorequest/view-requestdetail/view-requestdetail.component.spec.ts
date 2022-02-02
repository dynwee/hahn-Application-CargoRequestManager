import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewRequestdetailComponent } from './view-requestdetail.component';

describe('ViewRequestdetailComponent', () => {
  let component: ViewRequestdetailComponent;
  let fixture: ComponentFixture<ViewRequestdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewRequestdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewRequestdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
