export interface CreateOrder {
  empId: number;
  shipperId: number;
  shipName: string;
  shipAddress: string;
  shipCity: string;
  orderDate: string;
  requiredDate: string;
  shippedDate: string;
  freight: number;
  shipCountry: string;
  productId: number;
  unitPrice: number;
  qty: number;
  discount: number;
}