import { IPagination } from './../shared/models/IPagination';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProductBrand } from '../shared/models/IProductBrand';
import { IProductType } from '../shared/models/IProductType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = "https://localhost:44338/api/";

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<IPagination>(this.baseUrl + 'Products');
  }

  getBrands(){
    return this.http.get<IProductBrand[]>(this.baseUrl + 'Products/Brands');
  }

  getTypes(){
    return this.http.get<IProductType[]>(this.baseUrl + 'Products/Types');
  }
}
