import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetCategoryComponent } from './asset-category/asset-category.component';
import { AngularMaterialModule } from 'src/app/angular.material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AssetCategoryAddComponent } from './asset-category/asset-category-add/asset-category-add.component';
import { AssetCategoryEditComponent } from './asset-category/asset-category-edit/asset-category-edit.component';
import { AssetSubCategoryComponent } from './asset-sub-category/asset-sub-category.component';
import { AssetSubCategoryAddComponent } from './asset-sub-category/asset-sub-category-add/asset-sub-category-add.component';
import { AssetSubCategoryEditComponent } from './asset-sub-category/asset-sub-category-edit/asset-sub-category-edit.component';
import { PopupHeaderComponent } from '../shared/popup-header/popup-header.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    AssetCategoryComponent,
    AssetCategoryAddComponent,
    AssetCategoryEditComponent,
    AssetSubCategoryComponent,
    AssetSubCategoryAddComponent,
    AssetSubCategoryEditComponent
  ],
  imports: [
    CommonModule,    
    AngularMaterialModule,
    ReactiveFormsModule,       
    SharedModule
  ],
})
export class MasterModule { }
