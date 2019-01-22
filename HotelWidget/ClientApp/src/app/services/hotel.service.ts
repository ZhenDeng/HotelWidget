import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Hotel } from '../models/hotel';

@Injectable()
export class HotelService {

  constructor(private http: HttpClient) { }

  loadTokyoHotels(fileName:string): Observable<Hotel[]> {
    return this.http.get("/api/hotel/GetTokyoHotel?fileName="+fileName)
      .pipe(catchError(this.handleError));
  }

  loadNYHotels(fileName:string): Observable<Hotel[]> {
    return this.http.get("/api/hotel/GetNewYorkHotel?fileName="+fileName)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.log('server error:', error);

    if (error.error instanceof ErrorEvent) {
      let errMessage = '';
      try {
        errMessage = error.error.message;
      } catch (err) {
        errMessage = error.statusText;
      }
      return Observable.throw(errMessage);
    }
    return Observable.throw(error.error || 'ASP.NET Core server error');
  }
}
