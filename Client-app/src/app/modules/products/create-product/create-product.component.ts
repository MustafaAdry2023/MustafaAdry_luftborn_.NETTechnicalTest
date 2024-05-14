import { Component } from '@angular/core';
import { ValidationCallbackData } from 'devextreme-angular/common';
import notify from 'devextreme/ui/notify';
import { ProductSharedService } from '../shared/services/productShared.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss'],
})
export class CreateProductComponent {
  loading = false;
  formData: any = {};

  constructor(
    private productService: ProductSharedService,
    private router: Router
  ) {}
  async onSubmit(e: Event) {
debugger
    e.preventDefault();
    console.log(this.formData);

    this.productService.addNewProduct(this.formData).subscribe(
      (response) => {
        console.log(response);
          notify('Product Added Successfuly');
          this.router.navigate(['/products']);
      },
      (err) => {
        console.log(err);
        notify(err.message);
      }
    );
  }



  validateNumber(e: ValidationCallbackData) {
    return e.value > 0;
  }
}
