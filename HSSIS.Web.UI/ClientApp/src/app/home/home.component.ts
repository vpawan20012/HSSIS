import { Component } from '@angular/core';
import { MasterDataService } from '../services/app-services/master-data/master-data.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private masterDataService: MasterDataService) {

  }
  ngOnInit(): void {
    // this.masterDataService.getAllAssetCategories().subscribe(
    //   {
    //     next: (response) => { 
    //       console.log(response);
    //     },
    //     error: (error) => { }
    //   });
  }
}

