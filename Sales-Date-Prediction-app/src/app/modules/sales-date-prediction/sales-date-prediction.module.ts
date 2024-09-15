import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { SharedModule } from '../shared/shared.module';
import { SalesDatePredictionRoutingModule } from './sales-date-prediction-routing.module';
import { ViewSalesDatePredictionComponent } from './view-sales-date-prediction/view-sales-date-prediction.component';
import { BACKEND_URL } from '../../injection-tokens';
import { GeneralConfig } from '../../config/general.config';
import { LoadInterceptor } from '../../interceptor';
import { OrderModule } from '../order/order.module';


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
