import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTerminalComponent } from './view-terminal.component';

describe('ViewTerminalComponent', () => {
  let component: ViewTerminalComponent;
  let fixture: ComponentFixture<ViewTerminalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewTerminalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTerminalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
