import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule , FormsModule } from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpDetailComponent } from './employee/emp-detail/emp-detail.component';
import { BenefitService } from './services/benefit.service';
import { EmpComponent } from './employee/emp.component';
import { DashboardComponent } from './benefits/dashboard.component';
import { EmplistComponent } from './common/emplist/emplist.component';
import { BenefitdependentComponent } from './common/benefitdependent/benefitdependent.component';
import { RunningtotalComponent } from './common/runningtotal/runningtotal.component';

@NgModule({
  declarations: [
    AppComponent,
    EmpDetailComponent,
    EmpComponent,
    DashboardComponent,
    EmplistComponent,
    BenefitdependentComponent,
    RunningtotalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule
  ],
  providers: [BenefitService],
  bootstrap: [AppComponent]
})
export class AppModule { }
