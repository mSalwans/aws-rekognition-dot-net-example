import { Component, OnInit } from '@angular/core';
import { ILabel } from 'src/models/label';

@Component({
  selector: 'app-image-to-text',
  templateUrl: './image-to-text.component.html',
  styleUrls: ['../app.component.less', './image-to-text.component.less']
})
export class ImageToTextComponent implements OnInit {

  response: string;
  imgUploaded: any;
  uploadTo = 'ImageToText';

  constructor() { }

  ngOnInit() {
  }

  // uploadedImage(imgs: string[]) {
  //   this.imgUploaded = imgs[0];
  // }

  getLabels(response: any) {
    this.response = response;
    console.log(this.response);
  }

  displayLabel(label: ILabel) {
    return label.name + '  ' + Math.trunc(label.confidence);
  }

  displayText(text: any) {
    return 'Text: ' + text.detectedText + ' | Confidence: ' + Math.trunc(text.confidence);
  }

}
