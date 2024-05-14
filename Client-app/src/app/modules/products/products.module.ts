import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  ProductsRoutingModule } from './products-routing.module';
import { FormsModule } from '@angular/forms';
import { ProductListComponent } from './product-list/product-list.component';
import { CreateProductComponent } from './create-product/create-product.component';
import { ProductSharedService } from './shared/services/productShared.service';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { DevExtremeModule } from 'devextreme-angular';
import { EditProductComponent } from './edit-product/edit-product.component';
@NgModule({
  declarations: [
    ProductListComponent,
    CreateProductComponent,
    EditProductComponent,
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    FormsModule,
    HttpClientModule,
    DevExtremeModule,
  ],
  providers:[
    ProductSharedService
  ]
})
export class ProductsModule { }
