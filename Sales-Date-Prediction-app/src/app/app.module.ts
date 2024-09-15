import { CommonModule } from '@angular/common';
import { HttpClient, provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { GeneralConfig } from './config/general.config';
import { BACKEND_URL } from './injection-tokens';
import { LoadInterceptor } from './interceptor';
import { OrderModule } from './modules/order/order.module';
import { SalesDatePredictionModule } from './modules/sales-date-prediction/sales-date-prediction.module';
import { SharedModule } from './modules/shared/shared.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatOptionModule,
    SalesDatePredictionModule,
    OrderModule,
    SharedModule
  ],
  providers: [
    provideHttpClient(
      withFetch(),
      withInterceptors([LoadInterceptor])
    ),
    HttpClient,
    { provide: BACKEND_URL, useValue: GeneralConfig.BACKEND_URL },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }