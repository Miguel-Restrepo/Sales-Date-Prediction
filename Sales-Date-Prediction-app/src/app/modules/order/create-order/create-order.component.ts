import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';


@Component({
  selector: 'app-create-order',
  templateUrl: './templates/create-order.component.html',
  styleUrl: './styles/create-order.component.scss'
})
export class CreateOrderComponent implements OnInit{
  public name: string = '';
  constructor(
    public dialogRef: MatDialogRef<CreateOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
    if (this.data) {
    }
  }


  public closed(): void {
    this.dialogRef.close();
  }

  orderForm = new FormGroup({
    employee: new FormControl('', [Validators.required]),
    shipName: new FormControl('', [Validators.required]),
    shipper: new FormControl('', [Validators.required]),
    shipAddress: new FormControl('', [Validators.required]),
    shipCity: new FormControl('', [Validators.required]),
    shipCountry: new FormControl('', [Validators.required]),
    orderDate: new FormControl(new Date()),
    requiredDate: new FormControl(new Date()),
    shippedDate: new FormControl(new Date()),
    freight: new FormControl(0, [Validators.required]),
    product: new FormControl('', [Validators.required]),
    unitPrice: new FormControl(0, [Validators.required]),
    quantity: new FormControl(0, [Validators.required]),
    discount: new FormControl(0, [Validators.required])
  });


  onSubmit() {
    console.log(this.orderForm.value);
  }

}
