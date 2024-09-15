import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { OrderModule } from './modules/order/order.module';
import { SalesDatePredictionModule } from './modules/sales-date-prediction/sales-date-prediction.module';
import { SharedModule } from './modules/shared/shared.module';
import { BACKEND_URL } from './injection-tokens';
import { GeneralConfig } from './config/general.config';
import { LoadInterceptor } from './interceptor';

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
    SalesDatePredictionModule,
    OrderModule,
    SharedModule
  ],
  providers: [
    provideHttpClient(withFetch()),
    HttpClient,
    { provide: BACKEND_URL, useValue: GeneralConfig.BACKEND_URL },
    { provide: HTTP_INTERCEPTORS, useClass: LoadInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }