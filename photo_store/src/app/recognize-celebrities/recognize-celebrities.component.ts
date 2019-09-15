import { Component, OnInit } from '@angular/core';
import { ILabel } from 'src/models/label';

@Component({
  selector: 'app-recognize-celebrities',
  templateUrl: './recognize-celebrities.component.html',
  styleUrls: ['./recognize-celebrities.component.less']
})
export class RecognizeCelebritiesComponent implements OnInit {

  response: string;
  imgUploaded: any;
  faces: any;
  markedImg: string;
  uploadTo = 'RecognizeCelebrities';

  constructor() { }

  ngOnInit() {
  }

  getLabels(response: any) {
    this.response = response;
    this.faces = response.celebrityFaces;
    console.log(this.response);
  }

  getMarkedImg(markedImg: any) {
    this.markedImg = markedImg;
  }

}
