import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVehicletypeComponent } from './add-vehicletype.component';

describe('AddVehicletypeComponent', () => {
  let component: AddVehicletypeComponent;
  let fixture: ComponentFixture<AddVehicletypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddVehicletypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddVehicletypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
