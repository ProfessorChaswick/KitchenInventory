import { Component, OnInit } from '@angular/core';
import { KitchenService } from './service/kitchen.service';
import { kitchen } from './models/kitchen.model';

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
