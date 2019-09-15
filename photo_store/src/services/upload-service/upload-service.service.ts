import { Injectable } from '@angular/core';
import { IResponse } from 'src/models/response';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { LoggerService } from '../logger-service/logger-service.service';


@Injectable({
  providedIn: 'root'
})
export class UploadService {

  private baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient,
              private loggerService: LoggerService) { }

  uploadFiles(formData: FormData, uploadTo: string): Observable<IResponse> {
    return this.http.post<IResponse>(this.baseUrl + uploadTo, formData)
      .pipe(
        tap(data => data, catchError(this.loggerService.handleError))
      );
  }


}
