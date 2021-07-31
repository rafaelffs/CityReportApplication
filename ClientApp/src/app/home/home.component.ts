import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Location } from '../../model/location';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public cityList: string[];
  public location: Location;
  public http: HttpClient;
  public baseUrl;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.getCities();
  }

  private getCities() {
    this.http.get<string[]>(this.baseUrl + 'api/WeatherForecast/GetAllCities').subscribe(result => {
      this.cityList = result;
    }, error => console.error(error));
  }

  getLocation(city: string) {
    this.location = undefined;
    let params = new HttpParams().set('city', city);
    this.http.get<Location>(this.baseUrl + 'api/WeatherForecast/GetCityCompleteData', { params: params }).subscribe((result) => {
      this.location = result;
    }, error => console.error(error));
  }


  changeCitySelected(city: string) {
    this.getLocation(city);
  }


  
}
