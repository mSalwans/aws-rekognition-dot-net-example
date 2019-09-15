import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetectLabelsComponent } from './detect-labels.component';

describe('DetectLabelsComponent', () => {
  let component: DetectLabelsComponent;
  let fixture: ComponentFixture<DetectLabelsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetectLabelsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetectLabelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
