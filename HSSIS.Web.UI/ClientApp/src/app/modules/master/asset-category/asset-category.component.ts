import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { MatTableDataSource } from '@angular/material/table';
import { AssetCategoryDataModel } from 'src/app/_models/data-models/asset-category-data-model';
import { MasterDataService } from 'src/app/services/app-services/master-data/master-data.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { AssetCategoryAddComponent } from './asset-category-add/asset-category-add.component';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';
import { AssetCategoryEditComponent } from './asset-category-edit/asset-category-edit.component';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ProgressIndicatorService } from 'src/app/services/core-services/progress-indicator-service/progress.indicator.service';
import { LiveAnnouncer } from '@angular/cdk/a11y';

@Component({
  selector: 'app-asset-category',
  templateUrl: './asset-category.component.html',
  styleUrls: ['./asset-category.component.css']
})
export class AssetCategoryComponent extends BaseComponent implements OnInit {
  showDeactivatedOptionForm: FormGroup;
  assetCategories: MatTableDataSource<AssetCategoryDataModel>;
  //@ViewChild('paginator') paginator: MatPaginator | null = null;
  // @ViewChild('MatSort') set matSort(sort: MatSort) {
  //   this.assetCategories.sort = sort;
  // }

  @ViewChild('paginator') paginator: MatPaginator | null = null;
  @ViewChild('sorter') sorter = new MatSort();

  displayedColumns: string[] = ['SerialNumber', 'assetCategoryName', 'description', 'Active', 'Actions'];
  constructor(public messageService: MessageService,
    private masterDataService: MasterDataService,
    private matDialog: MatDialog,
    private formBuilder: FormBuilder,
    public progressIndicatorService:ProgressIndicatorService,
    private liveAnnouncer: LiveAnnouncer) {
    super(messageService);
    this.assetCategories = new MatTableDataSource();
    this.showDeactivatedOptionForm = this.formBuilder.group({
      showDeactivated: false
    });
  }

  override ngOnInit(): void {
    
  }

  ngAfterViewInit() {
    this.loadAssetCategories();
  }  

  loadAssetCategories(): void {
    var show: boolean = this.showDeactivatedOptionForm.value.showDeactivated != null && this.showDeactivatedOptionForm.value.showDeactivated == true;
    this.masterDataService.getAllAssetCategories(show)
      .subscribe({
        next: (response) => {
          if (response.isSuccess == true) {
            //console.log(response.result);
            this.assetCategories = new MatTableDataSource(response.result);
            this.assetCategories.paginator = this.paginator;
            this.assetCategories.sort = this.sorter;
          }
          else {
            super.handleResponseError(response);
          }
        },
        error: (error) => {
          super.showSnackBarError(error);
        }
      });
  }

  onAssetCategoryAdd() {
    const dialogRef = this.matDialog.open(AssetCategoryAddComponent
      , {
        "width": '600px',
        "maxHeight": '500px',
        "autoFocus": false,
        "hasBackdrop": true,
        "disableClose": true,
      }
    );
    dialogRef.afterClosed().subscribe(result => {
      if (result.event == 'Add') {
        this.loadAssetCategories();
      }
    });
  }

  onEditAssetCategory(assetCategoryId: number) {
    //console.log(assetCategoryId);
    var assetCategoryObservable = this.masterDataService.getAssetCategoryById(assetCategoryId);
    assetCategoryObservable.subscribe({
      next: (response) => {
        if (response.isSuccess == true) {
          const dialogRef = this.matDialog.open(AssetCategoryEditComponent
            , {
              "width": '800px',
              "maxHeight": '800px',
              "autoFocus": false,
              "hasBackdrop": true,
              "disableClose": true,
              "data": response.result
            }
          );
          dialogRef.afterClosed().subscribe(result => {
            if (result.event == 'Update') {
              this.loadAssetCategories();
            }
          });
        }
        else {
          super.handleResponseError(response);
        }
      },
      error: (error) => { super.showSnackBarError(error); }
    });
  }

  onDeactivateAssetCategory(assetCategoryId: number) {
    var assetCategoryObservable = this.masterDataService.getAssetCategoryById(assetCategoryId);
    assetCategoryObservable.subscribe({
      next: (response) => {
        if (response.isSuccess == true) {
          let assetCategory: AssetCategoryDataModel = response.result;
          let confirmMessage = 'Are you sure you want to deactivate Asset category: ' + assetCategory.assetCategoryName;
          const dialogRef = super.showConfirmationMessage('Deactivate Asset Category', confirmMessage, 'Yes, Deactivate it!', 'warning');
          dialogRef.then((result) => {
            if (result.isConfirmed) {
              assetCategory.updatedBy = 0;
              this.masterDataService
                .deactivateAssetCategory(assetCategory)
                .subscribe({
                  next: (response) => {
                    if (response.isSuccess == false) {
                      super.handleResponseError(response);
                    } else {
                      this.loadAssetCategories();
                      super.showSnackBarInfo(response.responseMessage.message);
                    }
                  },
                  error: (error) => { super.showSnackBarError(error); }
                });
            }
          });
        }
        else {
          super.handleResponseError(response);
        }
      },
      error: (error) => { super.showSnackBarError(error); }
    });
  }

  onActivateAssetCategory(assetCategoryId: number) {
    var assetCategoryObservable = this.masterDataService.getAssetCategoryById(assetCategoryId);
    assetCategoryObservable.subscribe({
      next: (response) => {
        if (response.isSuccess == true) {
          let assetCategory: AssetCategoryDataModel = response.result;
          let confirmMessage = 'Are you sure you want to activate Asset category: ' + assetCategory.assetCategoryName;
          const dialogRef = super.showConfirmationMessage('Activate Asset Category', confirmMessage, 'Yes, activate it!', 'warning');
          dialogRef.then((result) => {
            if (result.isConfirmed) {
              assetCategory.updatedBy = 0;
              this.masterDataService
                .activateAssetCategory(assetCategory)
                .subscribe({
                  next: (response) => {
                    if (response.isSuccess == false) {
                      super.handleResponseError(response);
                    } else {
                      this.loadAssetCategories();
                      super.showSnackBarInfo(response.responseMessage.message);
                    }
                  },
                  error: (error) => { super.showSnackBarError(error); }
                });
            }
          });
        }
        else {
          super.handleResponseError(response);
        }
      },
      error: (error) => { super.showSnackBarError(error); }
    });
  }

  onShowDeactivatedChange(event: any) {
    this.loadAssetCategories();
  }

  onSortingChange(sortState: Sort) {
    if (sortState.direction) {
      this.liveAnnouncer.announce('sorted ${sortState.direction} ending');
    }
    else {
      this.liveAnnouncer.announce('sorting cleared');
    }
  }
}
