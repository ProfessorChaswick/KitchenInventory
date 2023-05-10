import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { kitchen } from '../models/kitchen.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KitchenService {

baseUrl = 'https://localhost:7105/api/Invintories'

  constructor(private http: HttpClient) { }
  //get full inventory
  GetFullInventory(): Observable<kitchen[]>
  {
    return this.http.get<kitchen[]>(this.baseUrl);
  }
}
