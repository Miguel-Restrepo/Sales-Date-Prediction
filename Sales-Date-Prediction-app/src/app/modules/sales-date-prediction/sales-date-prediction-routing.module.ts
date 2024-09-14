import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewSalesDatePredictionComponent } from './view-sales-date-prediction/view-sales-date-prediction.component';

const routes: Routes = [
  {
    path: 'view',
    component: ViewSalesDatePredictionComponent
  },
  {
    path: '**',
    redirectTo: 'view'
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesDatePredictionRoutingModule { }
