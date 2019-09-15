import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecognizeCelebritiesComponent } from './recognize-celebrities.component';

describe('RecognizeCelebritiesComponent', () => {
  let component: RecognizeCelebritiesComponent;
  let fixture: ComponentFixture<RecognizeCelebritiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecognizeCelebritiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecognizeCelebritiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
