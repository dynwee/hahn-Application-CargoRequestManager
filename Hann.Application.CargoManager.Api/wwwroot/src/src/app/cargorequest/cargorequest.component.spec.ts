import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargorequestComponent } from './cargorequest.component';

describe('CargorequestComponent', () => {
  let component: CargorequestComponent;
  let fixture: ComponentFixture<CargorequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CargorequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CargorequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
