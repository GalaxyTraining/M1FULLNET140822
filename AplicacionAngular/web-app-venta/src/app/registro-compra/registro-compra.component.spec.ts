import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroCompraComponent } from './registro-compra.component';

describe('RegistroCompraComponent', () => {
  let component: RegistroCompraComponent;
  let fixture: ComponentFixture<RegistroCompraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistroCompraComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegistroCompraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
