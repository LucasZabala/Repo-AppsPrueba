import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteElement } from './delete-element';

describe('DeleteElement', () => {
  let component: DeleteElement;
  let fixture: ComponentFixture<DeleteElement>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteElement]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteElement);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
