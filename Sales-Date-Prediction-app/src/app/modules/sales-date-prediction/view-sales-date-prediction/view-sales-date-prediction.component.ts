import { LiveAnnouncer } from '@angular/cdk/a11y';
import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CustomerOrderPrediction, Order } from '../../../models';
import { CustomService } from '../../../services';
import { CreateOrderComponent } from '../../order/create-order/create-order.component';
import { ViewOrderComponent } from '../../order/view-order/view-order.component';


@Component({
  selector: 'app-view-sales-date-prediction',
  templateUrl: './templates/view-sales-date-prediction.component.html',
  styleUrl: './styles/view-sales-date-prediction.component.scss'
})
export class ViewSalesDatePredictionComponent implements AfterViewInit, OnInit {

  public displayedColumns: string[] = ['companyName', 'lastOrderDate', 'nextPredictedOrder', 'actions'];
  public searchQuery: string = '';
  private customers: CustomerOrderPrediction[] = [];
  public dataSource = new MatTableDataSource(this.customers);

  private _liveAnnouncer = inject(LiveAnnouncer);

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(public dialog: MatDialog,
    private customService: CustomService,
  ) { }

  ngOnInit(): void {
    this.onSearch();
  }

  ngAfterViewInit() {
    this.reloadDataSource();
  }

  public onSearch() {
    this.customService.getCustomerOrderPredictio(this.searchQuery).subscribe(
      (data: CustomerOrderPrediction[]) => {
        this.customers = data;
        this.reloadDataSource();
      }
    );
  }

  public announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  public openDialogCreateOrder(customerId: number): void {
    const dialogRef = this.dialog.open(CreateOrderComponent, {
      width: '40vw',
      height: 'auto',
      maxWidth: '90vw',
      data: {
        customerId: customerId,
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  public openDialogViewOrder(customerId: number, customerName: string): void {
    this.customService.getOrdersByCustomerId(customerId).subscribe(
      (data: Order[]) => {
        const dialogRef = this.dialog.open(ViewOrderComponent, {
          width: '80vw',
          height: 'auto',
          maxWidth: '90vw',
          data: {
            customerName: customerName,
            data: data,
          }
        });

        dialogRef.afterClosed().subscribe(result => {
          console.log('The dialog was closed');
        });
      }
    );

  }

  protected reloadDataSource() {
    this.dataSource = new MatTableDataSource(this.customers);
    if (this.paginator)
      this.dataSource.paginator = this.paginator;
    if (this.sort)
      this.dataSource.sort = this.sort;
  }
}
