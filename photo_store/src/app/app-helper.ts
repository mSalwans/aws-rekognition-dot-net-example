import { Injectable } from '@angular/core';
import { promise } from 'protractor';
import { MatSnackBar } from '@angular/material';

@Injectable()
export class AppHelper {

    constructor(private snackBar: MatSnackBar){}

    isImage(file: File): boolean {
        if (file.type.match(/image\/*/) == null) {
            return false;
        }
        return true;
    }

    convertToArrayBuffer(file: File, callback: any) : void {
        let reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = (_event: any) => {
            callback(reader.result);
        };

    }

    showMessage(msg: string){
        this.snackBar.open(msg, 'Close', {
        duration: 3000,
        });
    }

}
