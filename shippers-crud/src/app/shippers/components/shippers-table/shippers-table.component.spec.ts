import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippersTableComponent } from './shippers-table.component';

describe('ShippersTableComponent', () => {
  let component: ShippersTableComponent;
  let fixture: ComponentFixture<ShippersTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShippersTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippersTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
