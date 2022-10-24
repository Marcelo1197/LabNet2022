import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

import { ShippersDialogComponent } from './shippers-dialog.component';

describe('ShippersDialogComponent', () => {
  let component: ShippersDialogComponent;
  let fixture: ComponentFixture<ShippersDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShippersDialogComponent ],
      providers: [
        {provide: MAT_DIALOG_DATA, useValue: {}}
      ],
      imports: [FormsModule, ReactiveFormsModule]
    })
    .compileComponents();
    fixture = TestBed.createComponent(ShippersDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    fixture = TestBed.createComponent(ShippersDialogComponent);
    const dialog = fixture.componentInstance;
    expect(dialog).toBeTruthy();
  });

  it('formGroup should have two inputs', () => {
    const formShippers = fixture.debugElement.nativeElement.querySelector("#formShipper");
    const inputElements = formShippers.querySelectorAll("input");
    expect(inputElements.length).toEqual(2);
  });

});
