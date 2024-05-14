import { Component, OnInit } from '@angular/core';
import { ProductSharedService } from '../shared/services/productShared.service';
import { ProductDTO } from '../shared/models/product-dto';
import { Router } from '@angular/router';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
})
export class ProductListComponent implements OnInit {
  constructor(private prodService: ProductSharedService,private router: Router) {

this.openAddProduct =  this.openAddProduct.bind(this);
this.DeleteIconClick = this.DeleteIconClick.bind(this);
this.UpdateIconClick = this.UpdateIconClick.bind(this);

  }
   productList : ProductDTO[] | any;
   updateBtnAccess = true;
   deleteBtnAccess = true;
   addBtnAccess = true;

  ngOnInit(): void {
    this.loadData();

  }


  openAddProduct(){
    this.router.navigate(['/products/create-product']);
  }

  UpdateIconClick(){

  }
  DeleteIconClick(e:any){
    console.log(e);
    console.log(e.row.data.id)
    this.prodService.deleteProduct(e.row.data.id).subscribe(
      (response) => {
        notify('Product deleted successfully', 'success');
        this.loadData();
    }
   , (err) => {
       notify(err);
    }
  );
  }



  loadData(){
    this.prodService.getAllProducts().subscribe(
      (response) => {
      this.productList = response;
    }
   , (err) => {
       notify(err);
    }
  );
  }
}
