import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MasterDataService } from '../services/app-services/master-data/master-data.service';
import { AssetCategoryDataModel } from '../_models/data-models/asset-category-data-model';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];
  
  constructor(private masterDataService: MasterDataService) {
    // http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
    //this.assetCategories = new MatTableDataSource();
  }

  ngOnInit(): void {
    //this.loadAssetCategories();
  }

  
  

}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
