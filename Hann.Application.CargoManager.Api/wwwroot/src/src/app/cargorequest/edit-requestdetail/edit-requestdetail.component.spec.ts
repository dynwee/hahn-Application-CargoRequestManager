import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRequestdetailComponent } from './edit-requestdetail.component';

describe('EditRequestdetailComponent', () => {
  let component: EditRequestdetailComponent;
  let fixture: ComponentFixture<EditRequestdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRequestdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditRequestdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
