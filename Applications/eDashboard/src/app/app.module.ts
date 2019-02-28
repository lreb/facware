import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { UiSwitchModule } from 'ngx-toggle-switch';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicComponent } from './modules/public/layout/public/public.component';
import { DashboardComponent } from './modules/dashboard/layout/dashboard/dashboard.component';
import { PrivateComponent } from './modules/private/layout/private/private.component';
import { AuthenticationComponent } from './modules/public/pages/authentication/authentication.component';
import { InternalErrorComponent } from './core/errors/internal-error/internal-error.component';
import { MaintenanceComponent } from './core/errors/maintenance/maintenance.component';
import { NotFoundComponent } from './core/errors/not-found/not-found.component';
import { ProductionPlanComponent } from './modules/dashboard/pages/production-plan/production-plan.component';
import { ProductionPlanRevisionsComponent } from './modules/dashboard/pages/production-plan-revisions/production-plan-revisions.component';
import { ProductionPlanAreasComponent } from './modules/dashboard/pages/production-plan-areas/production-plan-areas.component';
import { ProductionPlanRolesComponent } from './modules/dashboard/pages/production-plan-roles/production-plan-roles.component';
import { FooterComponent } from './core/components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    PublicComponent,
    DashboardComponent,
    PrivateComponent,
    InternalErrorComponent,
    MaintenanceComponent,
    NotFoundComponent,
    AuthenticationComponent,
    ProductionPlanComponent,
    ProductionPlanRevisionsComponent,
    ProductionPlanAreasComponent,
    ProductionPlanRolesComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    UiSwitchModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
