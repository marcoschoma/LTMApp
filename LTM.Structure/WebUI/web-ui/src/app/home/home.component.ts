import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product/product.service';
import { Product } from '../model/product';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    private products: Product[];
    constructor(private productService: ProductService) {

    }
    ngOnInit(): void {
        this.productService.get().subscribe((result) => {
            this.products = result;
        });
    }
}
