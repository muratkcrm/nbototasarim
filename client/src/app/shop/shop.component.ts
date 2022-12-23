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
  brandIdSelected = 0;
  typeIdSelected = 0;


  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();

  }

  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected).subscribe(response => {
      this.products = response!.data;
      console.log(this.products);
    }, err => {
      console.log(err);
    });
  }

  getBrands(){
    this.shopService.getBrands().subscribe(response=>{
      var firstItem = {id : 0, name:'All', Description:'All'};
        this.brands = [firstItem , ...response];

      }, err =>{
      console.log(err);
    })
  }

  getTypes(){
    this.shopService.getTypes().subscribe(response=>{
      var firstItem = {id : 0, name:'All', Description:'All'};
        this.types = [firstItem , ...response];
      
    }, err =>{
      console.log(err);
    })
  }
 
  onBrandSelected(brandId:number){
    this.brandIdSelected = brandId;
    this.getProducts();
  }
    onTypeSelected(typeId:number){
      this.typeIdSelected = typeId;
      this.getProducts();
    }



}
