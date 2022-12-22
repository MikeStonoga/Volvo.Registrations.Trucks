import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckModelSelectorComponent } from './truck-model-selector.component';

describe('TruckModelSelectorComponent', () => {
  let component: TruckModelSelectorComponent;
  let fixture: ComponentFixture<TruckModelSelectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TruckModelSelectorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TruckModelSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
