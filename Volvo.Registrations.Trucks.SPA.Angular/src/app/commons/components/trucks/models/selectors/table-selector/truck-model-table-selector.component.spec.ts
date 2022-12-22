import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckModelTableSelectorComponent } from './truck-model-table-selector.component';

describe('TruckModelTableSelectorComponent', () => {
  let component: TruckModelTableSelectorComponent;
  let fixture: ComponentFixture<TruckModelTableSelectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TruckModelTableSelectorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TruckModelTableSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
