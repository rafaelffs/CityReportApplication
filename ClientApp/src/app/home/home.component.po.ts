import { browser, by, element, promise } from "protractor";

export class HomePage {
  navigateTo() {
    return browser.get('/');
  }

  getLoadingComponent() {
    element(by.css('.tableLabel')).getText().then(result => {
      return result;
    });
  }
}
