export interface Order {
  orderId: number;
  custId: number;
  customerName: string;
  empId: number;
  employeeName: string;
  orderDate: string;
  requiredDate: string;
  shippedDate: string;
  shipperId: number;
  shipperName: string;
  freight: number;
  shipName: string;
  shipAddress: string;
  shipCity: string;
  shipRegion: string;
  shipPostalCode: string;
  shipCountry: string;
}
