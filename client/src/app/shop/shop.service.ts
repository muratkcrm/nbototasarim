import { IPagination } from './../shared/models/IPagination';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = "https://localhost:44338/api/";

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<IPagination>(this.baseUrl + 'Products');
  }
}
