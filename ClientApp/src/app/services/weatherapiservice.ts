import { HttpClient, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Location } from '../../model/location';

@Injectable({
  providedIn: 'root'
})
export class WeatherAPIService {
  public http: HttpClient;
  public baseUrl;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  getCities(): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + 'api/WeatherForecast/GetAllCities');
  }

  getLocation(city: string): Observable<Location> {
    let params = new HttpParams().set('city', city);
    return this.http.get<Location>(this.baseUrl + 'api/WeatherForecast/GetCityCompleteData', { params: params });
  }
}
