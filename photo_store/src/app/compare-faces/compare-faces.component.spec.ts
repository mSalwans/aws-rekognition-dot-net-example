import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompareFacesComponent } from './compare-faces.component';

describe('CompareFacesComponent', () => {
  let component: CompareFacesComponent;
  let fixture: ComponentFixture<CompareFacesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompareFacesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompareFacesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
