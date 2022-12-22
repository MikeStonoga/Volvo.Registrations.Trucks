import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckRegistryComponent } from './truck-registry.component';

describe('TruckRegistryComponent', () => {
  let component: TruckRegistryComponent;
  let fixture: ComponentFixture<TruckRegistryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TruckRegistryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TruckRegistryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
