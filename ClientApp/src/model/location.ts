import { Astronomy } from "./astronomy";
import { CurrentCondition } from "./currentCondition";

export class Location {
  name: string;
  region: string;
  country: string;
  latitude: number;
  longitude: number;
  currentDateTime: string;
  sunrise: string;
  sunset: string;
  moonPhase: string;
  currentCondition: CurrentCondition;
  astronomy: Astronomy;
}
