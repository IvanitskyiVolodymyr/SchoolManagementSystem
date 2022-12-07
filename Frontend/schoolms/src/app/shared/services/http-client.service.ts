import { HttpClient, HttpContext, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  public baseUrl: string = 'https://localhost:7059/api';

  constructor(private http: HttpClient) {}

  public getFullRequest<T>(
    url: string,
    httpParams?: any,
    headers?: HttpHeaders | { [p: string]: string | string[] },
  ): Observable<HttpResponse<T>> {
    return this.http.get<T>(this.buildUrl(url), {
      observe: 'response',
      headers,
      params: httpParams,
    });
  }

  public postFullRequest<T>(
    url: string,
    payload: object,
    headers?: HttpHeaders | { [p: string]: string | string[] },
  ): Observable<HttpResponse<T>> {
    return this.http.post<T>(
      this.buildUrl(url),
      payload,
      {
        headers,
        observe: 'response',
      }
    );
  }

  public putFullRequest<T>(
    url: string,
    payload: object,
    headers?: HttpHeaders | { [p: string]: string | string[] },
  ): Observable<HttpResponse<T>> {
    return this.http.put<T>(this.buildUrl(url), payload, {
      headers,
      observe: 'response',
    });
  }

  public deleteFullRequest<T>(
    url: string,
    httpParams?: any,
    headers?: HttpHeaders | { [p: string]: string | string[] },
  ): Observable<HttpResponse<T>> {
    return this.http.delete<T>(this.buildUrl(url), {
      headers,
      observe: 'response',
      params: httpParams,
    });
  }

  public buildUrl(url: string): string {
    if (url.startsWith('http://') || url.startsWith('https://')) {
      return url;
    }
    return this.baseUrl + url;
  }
}
