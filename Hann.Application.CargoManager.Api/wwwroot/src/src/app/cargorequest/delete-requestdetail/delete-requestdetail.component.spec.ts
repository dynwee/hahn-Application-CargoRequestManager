import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteRequestdetailComponent } from './delete-requestdetail.component';

describe('DeleteRequestdetailComponent', () => {
  let component: DeleteRequestdetailComponent;
  let fixture: ComponentFixture<DeleteRequestdetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteRequestdetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteRequestdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
