import { Injectable } from '@angular/core';
import { throwError, Observable } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  static handleError: (err: any, caught: Observable<{}>) => never;

  constructor() { }

  handleError(err: HttpErrorResponse) {
    let errorMsg = '';

    if(err.error instanceof ErrorEvent){
      errorMsg = 'Client side error: ' + err.error.message;
    }else{
      errorMsg = 'Server error code:' + err.status + '\n Message: ' + err.message + '\n Error: ' + err.error;
    }
    console.log(errorMsg);
    return throwError(err.error.message);
  };

}
