import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductDTO } from '../models/product-dto';


@Injectable({
  providedIn: 'root',
})
export class ProductSharedService {

  constructor(private http: HttpClient) {


  }
  private getAllProductsUrl = environment.apiBaseUrl + 'product/GetAllProducts';
  private addNewProductUrl = environment.apiBaseUrl + 'product/AddNewProduct';
  private deleteProductUrl = environment.apiBaseUrl + 'product/DeleteProduct';
  private updateProductUrl = environment.apiBaseUrl + 'product/UpdateProduct';

  getAllProducts(): Observable<any> {
    return this.http.get<any>(this.getAllProductsUrl);
  }

  addNewProduct(formData:ProductDTO):Observable<any> {
    return this.http.post<any>(this.addNewProductUrl,formData);
  }
   deleteProduct(id:number):Observable<any> {
    return this.http.delete<any>(`${this.deleteProductUrl}?id=${id}`);
  }
  updateProduct(formData:ProductDTO):Observable<any> {
    return this.http.put<any>(this.updateProductUrl,formData);
  }
}
