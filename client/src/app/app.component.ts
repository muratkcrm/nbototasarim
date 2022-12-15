import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'NB Oto Tasarim';

  constructor() { }
  ngOnInit(): void {
    // this.http.get<any>('https://localhost:44338/api/products').subscribe((response: IPagination) => {

    //   this.products = response.data;

    // }, error => {
    //   console.log(error);
    // });
  }
}
