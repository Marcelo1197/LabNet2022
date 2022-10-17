import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippersFormComponent } from './shippers-form.component';

describe('ShippersFormComponent', () => {
  let component: ShippersFormComponent;
  let fixture: ComponentFixture<ShippersFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShippersFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
