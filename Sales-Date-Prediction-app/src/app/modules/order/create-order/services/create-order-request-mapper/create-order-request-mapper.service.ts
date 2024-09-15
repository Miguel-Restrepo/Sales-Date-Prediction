import { Injectable } from '@angular/core';
import { CreateOrder } from '../../../../../models';

@Injectable({
  providedIn: 'root'
})
export class CreateOrderRequestMapperService {

  constructor() { }

  map(request: any): CreateOrder {
    return {
      discount: request.discount,
      empId: request.empId,
      freight: request.freight,
      orderDate: request.orderDate,
      productId: request.productId,
      qty: request.empId,
      requiredDate: request.requiredDate,
      shipAddress: request.shipAddress,
      shipCity: request.shipCity,
      shipCountry: request.shipCountry,
      shipName: request.shipName,
      shippedDate: request.shippedDate,
      shipperId: request.shipperId,
      unitPrice: request.unitPrice
    } as CreateOrder;
  }
}
