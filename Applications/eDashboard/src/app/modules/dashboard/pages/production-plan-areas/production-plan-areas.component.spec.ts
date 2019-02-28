import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionPlanAreasComponent } from './production-plan-areas.component';

describe('ProductionPlanAreasComponent', () => {
  let component: ProductionPlanAreasComponent;
  let fixture: ComponentFixture<ProductionPlanAreasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductionPlanAreasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionPlanAreasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
