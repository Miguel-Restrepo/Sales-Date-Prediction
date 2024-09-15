import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomService } from '../../services';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { BACKEND_URL } from '../../injection-tokens';
import { GeneralConfig } from '../../config/general.config';
import { LoadInterceptor } from '../../interceptor';
import { SpinnerComponent } from './spinner/spinner.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';



@NgModule({
  declarations: [SpinnerComponent],
  imports: [
    CommonModule,
    MatProgressSpinnerModule
  ],
  providers: [
    CustomService,
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
