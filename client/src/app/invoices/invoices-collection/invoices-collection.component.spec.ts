import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoicesCollectionComponent } from './invoices-collection.component';

describe('InvoicesCollectionComponent', () => {
  let component: InvoicesCollectionComponent;
  let fixture: ComponentFixture<InvoicesCollectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvoicesCollectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvoicesCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
