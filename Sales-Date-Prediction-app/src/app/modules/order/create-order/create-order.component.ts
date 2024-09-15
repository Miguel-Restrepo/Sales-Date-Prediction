import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Employee, Product, Shipper } from '../../../models';
import { CustomService, EmployeeService, ProductService, ShipperService } from '../../../services';
import { CreateOrderRequestMapperService } from './services';

@Component({
  selector: 'app-create-order',
  templateUrl: './templates/create-order.component.html',
  styleUrl: './styles/create-order.component.scss'
})
export class CreateOrderComponent implements OnInit {
  public name: string = '';
  public employees: Employee[] = [];
  public products: Product[] = [];
  public shippers: Shipper[] = [];
  public orderForm = new FormGroup({
    empId: new FormControl('', [Validators.required]),
    shipName: new FormControl('', [Validators.required]),
    shipperId: new FormControl('', [Validators.required]),
    shipAddress: new FormControl('', [Validators.required]),
    shipCity: new FormControl('', [Validators.required]),
    shipCountry: new FormControl('', [Validators.required]),
    orderDate: new FormControl(new Date()),
    requiredDate: new FormControl(new Date()),
    shippedDate: new FormControl(new Date()),
    freight: new FormControl(0, [Validators.required]),
    productId: new FormControl('', [Validators.required]),
    unitPrice: new FormControl(0, [Validators.required]),
    qty: new FormControl(0, [Validators.required]),
    discount: new FormControl(0, [Validators.required])
  });

  constructor(
    public dialogRef: MatDialogRef<CreateOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private customService: CustomService,
    private employeeService: EmployeeService,
    private shipperService: ShipperService,
    private productService: ProductService,
    private mapperService: CreateOrderRequestMapperService
  ) { }

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe(
      (data: Employee[]) => {
        this.employees = data;
      }
    );
    this.shipperService.getShippers().subscribe(
      (data: Shipper[]) => {
        this.shippers = data;
      }
    );
    this.productService.getProducts().subscribe(
      (data: Product[]) => {
        this.products = data;
      }
    );
  }

  public closed(): void {
    this.dialogRef.close();
  }

  public onSubmit() {
    console.log(this.orderForm.value);
    this.customService.createOrder(this.mapperService.map(this.orderForm.value)).subscribe(
      () => {
        this.dialogRef.close();
      }
    );
  }
}
