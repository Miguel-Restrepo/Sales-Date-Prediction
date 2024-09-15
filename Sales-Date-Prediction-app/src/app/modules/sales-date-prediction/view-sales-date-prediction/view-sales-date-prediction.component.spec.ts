import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ViewSalesDatePredictionComponent } from './view-sales-date-prediction.component';

describe('ViewSalesDatePredictionComponent', () => {
  let component: ViewSalesDatePredictionComponent;
  let fixture: ComponentFixture<ViewSalesDatePredictionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewSalesDatePredictionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSalesDatePredictionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
