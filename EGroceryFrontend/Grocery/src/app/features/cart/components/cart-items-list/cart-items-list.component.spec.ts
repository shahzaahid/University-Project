import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartItemsListComponent } from './cart-items-list.component';

describe('CartItemsListComponent', () => {
  let component: CartItemsListComponent;
  let fixture: ComponentFixture<CartItemsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CartItemsListComponent]
    });
    fixture = TestBed.createComponent(CartItemsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
