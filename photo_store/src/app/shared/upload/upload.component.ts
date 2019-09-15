import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { AppHelper } from 'src/app/app-helper';
import { IResponse } from 'src/models/response';
import { UploadService } from 'src/services/upload-service/upload-service.service';
import { MatSnackBar } from '@angular/material';
 
@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.less']
})
export class UploadComponent implements OnInit {

  // tslint:disable-next-line: no-output-on-prefix
  @Output() public onUploadFinished = new EventEmitter();
  @Output() public markedImg = new EventEmitter();
  @Output() public selectedImages = new EventEmitter<string[]>();
  @Input() public uploadTo: string;

  imgsUploaded: string[] = [];
  spinner = false;

  constructor(private uploadService: UploadService,
              private appHelper: AppHelper) { }

  ngOnInit() {
  }

  public uploadFile = (files) => {
    this.spinner = true;
    this.imgsUploaded = [];

    if (files.length === 0) {
      return;
    }

    if (!this.appHelper.isImage(files[0])) {
      this.appHelper.showMessage('Only images are supported.');
      return;
    }

    for (let i = 0; i < files.length; i ++) {
      let reader = new FileReader();
      reader.readAsDataURL(files[i] as File);
      reader.onload = (event) => {
        this.imgsUploaded.push(reader.result.toString());

      };
    }

    const formData = new FormData();

    for (let file of files) {
      formData.append(file.name, file);
    }

    this.uploadService.uploadFiles(formData, this.uploadTo).subscribe(
      (data) => {
        this.onUploadFinished.emit(data.response);
        this.markedImg.emit(data.markedImg);
        this.spinner = false;
      },
      (error) => {
        this.appHelper.showMessage('Error: ' + error);
      }
    );

  }

}


