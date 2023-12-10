import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AssetCategoryDataModel } from 'src/app/_models/data-models/asset-category-data-model';
import { MasterDataService } from 'src/app/services/app-services/master-data/master-data.service';
import { ProgressIndicatorService } from 'src/app/services/core-services/progress-indicator-service/progress.indicator.service';
import { AssetSubCategoryViewModel } from 'src/app/_models/view-models/asset-sub-category-vide-model';
import { AssetSubCategoryAddComponent } from './asset-sub-category-add/asset-sub-category-add.component';
import { AssetSubCategoryEditComponent } from './asset-sub-category-edit/asset-sub-category-edit.component';
import { AssetSubCategoryDataModel } from 'src/app/_models/data-models/asset-sub-category-data-model';

@Component({
  selector: 'app-asset-sub-category',
  templateUrl: './asset-sub-category.component.html',
  styleUrls: ['./asset-sub-category.component.css']
})
export class AssetSubCategoryComponent extends BaseComponent implements OnInit {
  showDeactivatedOptionForm: FormGroup;
  assetSubCategories: MatTableDataSource<AssetSubCategoryViewModel>;
  assetCategories: AssetCategoryDataModel[] = [];
  @ViewChild('paginator') paginator: MatPaginator | null = null;
  @ViewChild('sorter') sorter = new MatSort();
  displayedColumns: string[] = ['SerialNumber', 'assetSubCategoryName', 'description', 'assetCategoryName', 'Active', 'Actions'];

  constructor(public messageService: MessageService,
    private masterDataService: MasterDataService,
    private matDialog: MatDialog,
    private formBuilder: FormBuilder,
    public progressIndicatorService: ProgressIndicatorService,
    private liveAnnouncer: LiveAnnouncer) {
    super(messageService);
    this.assetSubCategories = new MatTableDataSource();
    this.showDeactivatedOptionForm = this.formBuilder.group({
      showDeactivated: false,
      assetCategoryId: 0
    });
  }

  override ngOnInit(): void {
    this.loadAssetCategories();
    this.loadAssetSubCategories();
  }

  loadAssetCategories(): void {
    this.masterDataService.getAllAssetCategories(false)
      .subscribe({
        next: (response) => {
          if (response.isSuccess == true) {
            this.assetCategories = response.result;
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

  loadAssetSubCategories(): void {
    const show: boolean = this.showDeactivatedOptionForm.value.showDeactivated != null && this.showDeactivatedOptionForm.value.showDeactivated == true;
    const assetCategoryId=this.showDeactivatedOptionForm.value.assetCategoryId;
    this.masterDataService.getAllAssetSubCategories(assetCategoryId, show)
      .subscribe({
        next: (response) => {
          if (response.isSuccess == true) {
            //console.log(response.result);
            this.assetSubCategories = new MatTableDataSource(response.result);
            this.assetSubCategories.paginator = this.paginator;
            this.assetSubCategories.sort = this.sorter;
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

  onAssetSubCategoryAdd() {
    const dialogRef = this.matDialog.open(AssetSubCategoryAddComponent
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
        this.loadAssetSubCategories();
      }
    });
  }

  onEditAssetSubCategory(assetSubCategoryId: number) {
    var assetSubCategoryObservable = this.masterDataService.getAssetSubCategoryById(assetSubCategoryId);
    assetSubCategoryObservable.subscribe({
      next: (response) => {
        if (response.isSuccess == true) {
          const dialogRef = this.matDialog.open(AssetSubCategoryEditComponent
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
              this.loadAssetSubCategories();
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

  onDeactivateAssetSubCategory(assetSubCategoryId: number) {
    var assetSubCategoryObservable = this.masterDataService.getAssetSubCategoryById(assetSubCategoryId);
    assetSubCategoryObservable.subscribe({
      next: (response) => {
        if (response.isSuccess == true) {
          let assetSubCategory: AssetSubCategoryDataModel = response.result;
          let confirmMessage = 'Are you sure you want to deactivate Asset Subcategory: ' + assetSubCategory.assetSubCategoryName;
          const dialogRef = super.showConfirmationMessage('Deactivate Asset SucCategory', confirmMessage, 'Yes, Deactivate it!', 'warning');
          dialogRef.then((result) => {
            if (result.isConfirmed) {
              assetSubCategory.updatedBy = 0;
              this.masterDataService
                .deactivateAssetSubCategory(assetSubCategory)
                .subscribe({
                  next: (response) => {
                    if (response.isSuccess == false) {
                      super.handleResponseError(response);
                    } else {
                      this.loadAssetSubCategories();
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

  onActivateAssetSubCategory(assetSubCategoryId: number) {
    var assetSubCategoryObservable = this.masterDataService.getAssetSubCategoryById(assetSubCategoryId);
    assetSubCategoryObservable.subscribe({
      next: (response) => {
        if (response.isSuccess == true) {
          let assetSubCategory: AssetSubCategoryDataModel = response.result;
          let confirmMessage = 'Are you sure you want to activate Asset Subcategory: ' + assetSubCategory.assetSubCategoryName;
          const dialogRef = super.showConfirmationMessage('Activate Asset SubCategory', confirmMessage, 'Yes, activate it!', 'warning');
          dialogRef.then((result) => {
            if (result.isConfirmed) {
              assetSubCategory.updatedBy = 0;
              this.masterDataService
                .activateAssetSubCategory(assetSubCategory)
                .subscribe({
                  next: (response) => {
                    if (response.isSuccess == false) {
                      super.handleResponseError(response);
                    } else {
                      this.loadAssetSubCategories();
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

  onFilterSelectionChange(event: any) {
    this.loadAssetSubCategories();
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
