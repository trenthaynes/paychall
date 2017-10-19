import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmpComponent } from './employee/emp.component';
import { DashboardComponent } from './benefits/dashboard.component';
import { EmpDetailComponent } from './employee/emp-detail/emp-detail.component';

const routes: Routes = [{
    path: 'detail/:id',
    component: EmpDetailComponent
  },{
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
  },{
    path: 'employees',
    component: EmpComponent
  },{
    path: 'dashboard',
    component: DashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
