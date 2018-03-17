import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { CarServiceProvider } from '../../providers/car-service/car-service';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  constructor(
    public navCtrl: NavController,
    private carService: CarServiceProvider) {}

  moveForward() {
    this.carService.moveForward()
      .subscribe(m => {
        console.log("moveForward", m);
      });
  }

  moveReverse() {
    this.carService.moveReverse()
      .subscribe(m => {
        console.log("moveReverse", m);
      });
  }

  moveLeft() {
    this.carService.moveLeft()
      .subscribe(m => {
        console.log("moveLeft", m);
      });
  }

  moveRight() {
    this.carService.moveRight()
      .subscribe(m => {
        console.log("moveRight", m);
      });
  }

  stopMoving() {
    this.carService.stopMoving()
      .subscribe(m => {
        console.log("stopMoving", m);
      });
  }
}
