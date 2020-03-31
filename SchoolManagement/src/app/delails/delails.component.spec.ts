import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DelailsComponent } from './delails.component';

describe('DelailsComponent', () => {
  let component: DelailsComponent;
  let fixture: ComponentFixture<DelailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DelailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DelailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
