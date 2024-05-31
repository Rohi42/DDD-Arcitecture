import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEditComponent } from './view-edit.component';

describe('ViewEditComponent', () => {
  let component: ViewEditComponent;
  let fixture: ComponentFixture<ViewEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewEditComponent]
    });
    fixture = TestBed.createComponent(ViewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
