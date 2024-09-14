import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewSalesDatePredictionComponent } from './view-sales-date-prediction/view-sales-date-prediction.component';
import { SalesDatePredictionRoutingModule } from './sales-date-prediction-routing.module';



@NgModule({
  declarations: [
    ViewSalesDatePredictionComponent
  ],
  imports: [
    CommonModule,
    SalesDatePredictionRoutingModule
  ]
})
export class SalesDatePredictionModule { }
