import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AssetCategoryDataModel } from 'src/app/_models/data-models/asset-category-data-model';
import { AssetSubCategoryDataModel } from 'src/app/_models/data-models/asset-sub-category-data-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MasterDataService {

  constructor(private http: HttpClient) { }

  //#region Asset Category
  getAllAssetCategories(showDeactivated:boolean): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/GetAllAssetCategories`;
    let parameters = new HttpParams().append('showDeactivated', showDeactivated);
    return this.http.get<any>(url, { params: parameters });
  }

  getAssetCategoryById(assetCategoryId: number): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/GetAssetCategoryById`;
    let parameters = new HttpParams().append('assetCategoryId', assetCategoryId);
    return this.http.get<any>(url, { params: parameters });
  }

  addAssetCategory(assetCategory: AssetCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/AddAssetCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetCategory, { 'headers': headers });
  }

  updateAssetCategory(assetCategory: AssetCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/UpdateAssetCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetCategory, { 'headers': headers });
  }

  deactivateAssetCategory(assetCategory: AssetCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/DeactivateAssetCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetCategory, { 'headers': headers });
  }

  activateAssetCategory(assetCategory: AssetCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/ActivateAssetCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetCategory, { 'headers': headers });
  }
  //#endregion

  //#region Asset Sub Category
  getAllAssetSubCategories(assetCategoryId:number, showDeactivated:boolean): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/GetAllAssetSubCategories`;
    let parameters = new HttpParams()    
    .append('assetCategoryId', assetCategoryId)
    .append('showDeactivated', showDeactivated);
    return this.http.get<any>(url, { params: parameters });
  }

  getAssetSubCategoryById(assetSubCategoryId: number): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/GetAssetSubCategoryById`;
    let parameters = new HttpParams().append('assetSubCategoryId', assetSubCategoryId);
    return this.http.get<any>(url, { params: parameters });
  }

  addAssetSubCategory(assetSubCategory: AssetSubCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/AddAssetSubCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetSubCategory, { 'headers': headers });
  }

  updateAssetSubCategory(assetSubCategory: AssetSubCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/UpdateAssetSubCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetSubCategory, { 'headers': headers });
  }

  deactivateAssetSubCategory(assetSubCategory: AssetSubCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/DeactivateAssetSubCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetSubCategory, { 'headers': headers });
  }

  activateAssetSubCategory(assetSubCategory: AssetSubCategoryDataModel): Observable<any> {
    var url = `${environment.apiUrl}/MasterData/ActivateAssetSubCategory`;
    const headers = new HttpHeaders().set('content-type', 'application/json')
    return this.http.post<any>(url, assetSubCategory, { 'headers': headers });
  }
  //#endregion
}
