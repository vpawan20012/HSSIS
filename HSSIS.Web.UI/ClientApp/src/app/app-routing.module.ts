import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AssetCategoryComponent } from './modules/master/asset-category/asset-category.component';
import { AssetSubCategoryComponent } from './modules/master/asset-sub-category/asset-sub-category.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  // { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },  
  // { path: '', redirectTo: 'home', pathMatch: 'full' },
  //{ path: '**', component: HomeComponent } // If no matching route found, go back to home route
  { path: '', component: HomeComponent, pathMatch: 'full' },
  //{ path: 'counter', component: CounterComponent },
  { path: 'assetcategory', component: AssetCategoryComponent },
  { path: 'assetsubcategory', component: AssetSubCategoryComponent },
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
