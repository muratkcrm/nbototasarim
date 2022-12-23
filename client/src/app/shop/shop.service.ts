import { IPagination } from './../shared/models/IPagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProductBrand } from '../shared/models/IProductBrand';
import { IProductType } from '../shared/models/IProductType';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = "https://localhost:44338/api/";

  constructor(private http: HttpClient) { }

  getProducts(brandId? : number, typeId? : number) {

    let params = new HttpParams();

    if(brandId){
      params = params.append('brandId', brandId.toString());
    }

    if(typeId){
      params = params.append('typeId',typeId.toString());
    }

    return this.http.get<IPagination>(this.baseUrl + 'Products', {observe: 'response', params})
    .pipe(
        map(response =>{
          return Response.body;
        })
      );
  }

  getBrands(){
    return this.http.get<IProductBrand[]>(this.baseUrl + 'Products/Brands');
  }

  getTypes(){
    return this.http.get<IProductType[]>(this.baseUrl + 'Products/Types');
  }
}
