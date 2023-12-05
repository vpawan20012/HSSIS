import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MasterDataService {

  constructor(private http: HttpClient) { }

  //#region Asset Category
  getAllAssetCategories():Observable<any> {
    var url = `${environment.apiUrl}/MasterData/GetAllAssetCategories`;
    return this.http.get<any>(url);
  }
  //#endregion
}
