import { HttpClient } from "@angular/common/http";
import { HomeComponent } from "./home.component";
import { Location } from '../../model/location';


describe('home', () => {
  it('Should return empty list if not cities are loaded', () => {
    var component: HomeComponent = new HomeComponent(new HttpClient(null), location.origin);
    expect(component.cityList).toBeUndefined();
  })

  it('Should not be empty if a list city is loaded', () => {
    var component: HomeComponent = new HomeComponent(new HttpClient(null), location.origin);
    component.cityList = ["City1", "City2"];
    expect(component.cityList.length).toBeGreaterThan(1);
  })

  it('Should return empty list if not locations are loaded', () => {
    var component: HomeComponent = new HomeComponent(new HttpClient(null), location.origin);
    expect(component.location).toBeUndefined();
  })

  it('Should not be empty if a location is loaded', () => {
    var component: HomeComponent = new HomeComponent(new HttpClient(null), location.origin);
    component.location = new Location();
    expect(component.location).toBeDefined();
  })

});


