import { ShopService } from './shop.service';
import { IProduct } from './../shared/models/IProduct';
import { Component, OnInit } from '@angular/core';
import { IProductBrand } from '../shared/models/IProductBrand';
import { IProductType } from '../shared/models/IProductType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  products!: IProduct[];
  brands!: IProductBrand[];
  types!: IProductType[];


  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();

  }

  getProducts() {
    this.shopService.getProducts().subscribe(response => {
      this.products = response.data;
      console.log(this.products);
    }, err => {
      console.log(err);
    });
  }

  getBrands(){
    this.shopService.getBrands().subscribe(Response=>{
      this.brands = Response;
    }, err =>{
      console.log(err); 
    })
  }

  getTypes(){
    this.shopService.getTypes().subscribe(Response=>{
      this.types = Response;
    }, err =>{
      console.log(err); 
    })
  }



}
