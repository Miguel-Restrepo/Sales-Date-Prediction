import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomService } from '../../services';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { BACKEND_URL } from '../../injection-tokens';
import { GeneralConfig } from '../../config/general.config';
import { LoadInterceptor } from '../../interceptor';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    CustomService,
    HttpClient,
    { provide: BACKEND_URL, useValue: GeneralConfig.BACKEND_URL },
    { provide: HTTP_INTERCEPTORS, useClass: LoadInterceptor, multi: true },
    provideHttpClient(withFetch())
  ],
})
export class SharedModule { }
