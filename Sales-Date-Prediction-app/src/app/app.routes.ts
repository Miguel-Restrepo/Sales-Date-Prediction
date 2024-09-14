import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./modules/sales-date-prediction/sales-date-prediction.module').then(m => m.SalesDatePredictionModule)
  },
  {
    path: 'orders',
    loadChildren: () => import('./modules/order/order.module').then(m => m.OrderModule)
  },
  {
    path: '**',
    redirectTo: 'home'
  },
];
