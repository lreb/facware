import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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

const PUBLIC_ROUTES: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'login', component: AuthenticationComponent },
    { path: '**', component: NotFoundComponent }
];

const PRIVATE_ROUTES: Routes = [
  // { path: '', redirectTo: 'shopfloor', pathMatch: 'full' },
  // { path: 'overview', component: OverviewComponent },
  // { path: 'shopfloor', children: PRIVATE_ROUTES_SHOPFLOOR },
  // { path: 'materials', children: PRIVATE_ROUTES_MATERIALS },
  // { path: 'orders', children: PRIVATE_ROUTES_ORDERS },
  // { path: 'manufacturing', children: PRIVATE_ROUTES_MANUFACTURING },
  // { path: 'externalevents', children: PRIVATE_ROUTES_EXTERNALEVENTS },
  { path: '**', component: NotFoundComponent }
];


// dashboard layout
const DASHBOARD_ROUTES: Routes = [
  { path: '', redirectTo: 'productionplan', pathMatch: 'full' },
  { path: 'productionplan', component: ProductionPlanComponent },
  { path: 'productionplan/revisions', component: ProductionPlanRevisionsComponent },
  { path: 'productionplan/areas', component: ProductionPlanAreasComponent },
  { path: 'productionplan/roles', component: ProductionPlanRolesComponent },
  { path: '**', component: NotFoundComponent }
];

const routes: Routes = [
  { path: '', redirectTo: 'public', pathMatch: 'full' },
  { path: 'public', component: PublicComponent, data: { title: 'Public Views'}, children: PUBLIC_ROUTES },
  { path: 'private', component: PrivateComponent, data: { title: 'Private Views'}
  , children: PRIVATE_ROUTES },
  { path: 'dashboard', component: DashboardComponent, data: { title: 'Dashboard modules'}
  , children: DASHBOARD_ROUTES },
  { path: 'login', component: AuthenticationComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
