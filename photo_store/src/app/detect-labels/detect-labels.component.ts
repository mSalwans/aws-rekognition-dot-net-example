import { Component, OnInit } from '@angular/core';
import { ILabel } from 'src/models/label';

@Component({
  selector: 'app-detect-labels',
  templateUrl: './detect-labels.component.html',
  styleUrls: ['../app.component.less', './detect-labels.component.less']
})
export class DetectLabelsComponent implements OnInit {

  labels: ILabel[];
  imgUploaded: any;
  markedImg: string;
  uploadTo = 'DetectLabels';

  constructor() { }

  ngOnInit() {
  }

  getLabels(response: any) {
    this.labels = response.labels;
  }

  displayLabel(label: ILabel) {
    return label.name + ' - ' + Math.trunc(label.confidence) + '%';
  }

  getMarkedImg(markedImg: any) {
    this.markedImg = markedImg;
  }

}
