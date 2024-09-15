import { CommonModule } from '@angular/common';
import { HttpClient, provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { GeneralConfig } from '../../config/general.config';
import { BACKEND_URL } from '../../injection-tokens';
import { LoadInterceptor } from '../../interceptor';
import { CustomService, EmployeeService, ProductService, ShipperService } from '../../services';
import { SpinnerComponent } from './spinner/spinner.component';

@NgModule({
  declarations: [SpinnerComponent],
  imports: [
    CommonModule,
    MatProgressSpinnerModule
  ],
  providers: [
    CustomService,
    EmployeeService,
    ProductService,
    ShipperService,
    HttpClient,
    { provide: BACKEND_URL, useValue: GeneralConfig.BACKEND_URL },
    provideHttpClient(
      withFetch(),
      withInterceptors([LoadInterceptor])
    ),
  ],
  exports: [
    SpinnerComponent
  ]
})
export class SharedModule { }
