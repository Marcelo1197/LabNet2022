import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippersDialogComponent } from './shippers-dialog.component';

describe('ShippersDialogComponent', () => {
  let component: ShippersDialogComponent;
  let fixture: ComponentFixture<ShippersDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShippersDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippersDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
