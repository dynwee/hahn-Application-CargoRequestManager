import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewVehicletypeComponent } from './view-vehicletype.component';

describe('ViewVehicletypeComponent', () => {
  let component: ViewVehicletypeComponent;
  let fixture: ComponentFixture<ViewVehicletypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewVehicletypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewVehicletypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
