import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

/*
  Generated class for the CarServiceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class CarServiceProvider {
  url: string = "http://192.168.43.9:5000/api/carmove";

  constructor(public http: HttpClient) {
    console.log('Hello CarServiceProvider Provider');
  }

  moveForward() {
    return this.move("forward", 1000);
  }  

  moveReverse() {
    return this.move("reverse", 1000);
  }  

  moveLeft() {
    return this.move("left", 1000);
  } 

  moveRight() {
    return this.move("right", 1000);
  }
  
  stopMoving() {
    return this.http.get(`${this.url}/stop`);      
  }

  private move(direction: string, milliseconds: number) {
    return this.http.get(`${this.url}/${direction}/${milliseconds}`);      
  }
}
