import { Component, OnInit } from '@angular/core';
import { Pipe, PipeTransform } from '@angular/core';
import { KitchenService } from './service/kitchen.service';
import { kitchen } from './models/kitchen.model';
import { orderBy } from 'lodash';

@Pipe({
  name: "orderBy"
 })
 export class OrderByPipe implements PipeTransform {
  transform(array: any, sortBy: string, order?: string): any[] {
  const sortOrder = order ? order : 'asc'; // setting default ascending order
 
   return orderBy(array, [sortBy], true);
   }
 }

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'kitchen';
  foods: kitchen[] = [];

  constructor(private kitchenService: KitchenService)
  {

  }

  ngOnInit(): void
  {
    this.getFullInv();
  }

  getFullInv()
  {
    this.kitchenService.GetFullInventory()
    .subscribe
    (
      response => {
        this.foods = response;
        console.log(response);
      }
    );
  }
}
