import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionPlanRolesComponent } from './production-plan-roles.component';

describe('ProductionPlanRolesComponent', () => {
  let component: ProductionPlanRolesComponent;
  let fixture: ComponentFixture<ProductionPlanRolesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductionPlanRolesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionPlanRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
