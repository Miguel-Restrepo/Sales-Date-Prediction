import { CommonModule } from '@angular/common';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { LoadInterceptor } from '../../interceptor';
import { OrderModule } from '../order/order.module';
import { SalesDatePredictionRoutingModule } from './sales-date-prediction-routing.module';
import { ViewSalesDatePredictionComponent } from './view-sales-date-prediction/view-sales-date-prediction.component';


@NgModule({
  declarations: [
    ViewSalesDatePredictionComponent
  ],
  imports: [
    CommonModule,
    SalesDatePredictionRoutingModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
    OrderModule
  ],
  exports: [
  ],
  providers: [
    provideHttpClient(
      withFetch(),
      withInterceptors([LoadInterceptor])
    ),
  ],
})
export class SalesDatePredictionModule { }
