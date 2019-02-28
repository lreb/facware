import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionPlanRevisionsComponent } from './production-plan-revisions.component';

describe('ProductionPlanRevisionsComponent', () => {
  let component: ProductionPlanRevisionsComponent;
  let fixture: ComponentFixture<ProductionPlanRevisionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductionPlanRevisionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionPlanRevisionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
