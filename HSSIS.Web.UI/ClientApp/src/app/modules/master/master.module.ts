import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetCategoryComponent } from './asset-category/asset-category.component';
import { AngularMaterialModule } from 'src/app/angular.material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AssetCategoryAddComponent } from './asset-category/asset-category-add/asset-category-add.component';
import { AssetCategoryEditComponent } from './asset-category/asset-category-edit/asset-category-edit.component';

@NgModule({
  declarations: [
    AssetCategoryComponent,
    AssetCategoryAddComponent,
    AssetCategoryEditComponent
  ],
  imports: [
    CommonModule,    
    AngularMaterialModule,
    ReactiveFormsModule,    
  ],
})
export class MasterModule { }
