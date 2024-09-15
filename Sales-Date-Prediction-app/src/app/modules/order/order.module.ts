import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { SharedModule } from '../shared/shared.module';
import { CreateOrderComponent } from './create-order/create-order.component';
import { OrderRoutingModule } from './order-routing.module';
import { ViewOrderComponent } from './view-order/view-order.component';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { BACKEND_URL } from '../../injection-tokens';
import { GeneralConfig } from '../../config/general.config';
import { LoadInterceptor } from '../../interceptor';
import { CustomService } from '../../services';
import { MatDialogModule } from '@angular/material/dialog';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
  declarations: [
    CreateOrderComponent,
    ViewOrderComponent
  ],
  imports: [
    CommonModule,
    OrderRoutingModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
    SharedModule,
    MatDialogModule,
    MatDatepickerModule, 
    MatNativeDateModule,
    ReactiveFormsModule
  ],
  providers: [
    provideHttpClient(
      withFetch(),
      withInterceptors([LoadInterceptor])
    ),
  ],
})
export class OrderModule { }
