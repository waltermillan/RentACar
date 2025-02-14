import { Price } from "./price.model";
import { Car } from "./car.model";

export interface CarPrice {
    car:Car;
    price:Price;
}