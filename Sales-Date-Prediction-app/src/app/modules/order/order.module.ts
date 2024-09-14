import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CreateOrderComponent } from './create-order/create-order.component';
import { OrderRoutingModule } from './order-routing.module';
import { ViewOrderComponent } from './view-order/view-order.component';



@NgModule({
  declarations: [
    CreateOrderComponent,
    ViewOrderComponent
  ],
  imports: [
    CommonModule,
    OrderRoutingModule
  ]
})
export class OrderModule { }
