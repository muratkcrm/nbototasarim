import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './shared/models/IPagination';
import { IProduct } from './shared/models/IProduct';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'E-Ticaret';
  products! :IProduct[];

  constructor(private http: HttpClient) { }
  ngOnInit(): void {
    this.http.get<any>('https://localhost:44338/api/products').subscribe((response: IPagination) => {

      //this.products = response.data;
      this.products = response.data;

    }, error => {
      console.log(error);
    });
  }
}
