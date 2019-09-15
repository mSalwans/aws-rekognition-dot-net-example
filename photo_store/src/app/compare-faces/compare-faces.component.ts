import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AppHelper } from '../app-helper';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { UploadService } from 'src/services/upload-service/upload-service.service';


export class ICompareFacesEntity
{
    sourceImg: string;
    targetImg: string;
}

@Component({
  selector: 'app-compare-faces',
  templateUrl: './compare-faces.component.html',
  styleUrls: ['../app.component.less', './compare-faces.component.less']
})
export class CompareFacesComponent implements OnInit {

  srcImg: any;
  trgtImg: any;
  uploadTo = 'CompareFaces';
  imgsUploaded: string[];

  faceMatches: any[] = [] ;
  unmatchedFaces: any[] = [];
  response: any;
  markedImg = '';

  spinner = false;

  formData = new ICompareFacesEntity();

  constructor(private uploadService: UploadService,
              private appHelper: AppHelper) { }

  ngOnInit() {

  }

  uploadedImage(imgs: string[]) {
    this.imgsUploaded = imgs;
  }

  getReponse(response: any) {
    this.response = response.response;
    this.faceMatches = response.response.faceMatches;
  }

  compareImgs(sourceImg: any, targetImg: any) {

    this.spinner = true;

    if (!this.appHelper.isImage(sourceImg[0]) || 
        !this.appHelper.isImage(targetImg[0])) {
          this.appHelper.showMessage('Only images are supported.');
      return;
    }

    let reader = new FileReader();
    reader.readAsDataURL(sourceImg[0]);
    reader.onload = (_event: any) => {
      this.srcImg = reader.result;

      reader.readAsDataURL(targetImg[0]);
      reader.onload = (_event: any) => {
        this.trgtImg = reader.result;

        const formData = new FormData();
        formData.append('sourceImg', sourceImg[0], sourceImg[0].name);
        formData.append('targetImg', targetImg[0], targetImg[0].name);


        // this.http.post(this.uploadTo, formData, {reportProgress: true, observe: 'events'})
        // .subscribe(event => {
        //   if (event.type === HttpEventType.UploadProgress) {
        //     this.progress = Math.round(100 * event.loaded / event.total);
        //   } else if (event.type === HttpEventType.Response) {
        //     this.message = 'Upload success.';
        //     let body = event.body as any;
        //     this.response = body.response;
        //     this.faceMatches = this.response.faceMatches;
        //     this.unmatchedFaces = this.response.unmatchedFaces;
        //     this.markedImg = body.markedImg;
        //     this.spinner = false;
        //   }
        // });


        this.uploadService.uploadFiles(formData, this.uploadTo).subscribe(
          (data) => {
            this.response = data.response;
            this.faceMatches = this.response.faceMatches;
            this.unmatchedFaces = this.response.unmatchedFaces;
            this.markedImg = data.markedImg;
            this.spinner = false;
          },
          (error) => {
            this.appHelper.showMessage('Error: ' + error);
          }
        );


      };
    };


  }

}

