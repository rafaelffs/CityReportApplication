import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Location } from '../../model/location';
import { WeatherAPIService } from '../services/weatherapiservice';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public cityList: string[];
  public location: Location;
  public weatherAPIservice: WeatherAPIService;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.weatherAPIservice = new WeatherAPIService(http, baseUrl);
  }

  ngOnInit() {
    this.loadCities();
  }

  changeCitySelected(city: string) {
    this.LoadCitySelected(city);
  }

  loadCities() {
    this.weatherAPIservice.getCities().subscribe(result => {
      this.cityList = result;
    }, error => console.error(error));;
  }

  LoadCitySelected(city: string) {
    this.location = undefined;
    this.weatherAPIservice.getLocation(city).subscribe((result) => {
      this.location = result;
    }, error => console.error(error));;
  }
}
