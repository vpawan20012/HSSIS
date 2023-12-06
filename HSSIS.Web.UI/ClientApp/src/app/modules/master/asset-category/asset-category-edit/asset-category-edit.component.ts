import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AssetCategoryDataModel } from 'src/app/_models/data-models/asset-category-data-model';
import { BaseComponent } from 'src/app/modules/base/base.component';
import { MasterDataService } from 'src/app/services/app-services/master-data/master-data.service';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';
import { ProgressIndicatorService } from 'src/app/services/core-services/progress-indicator-service/progress.indicator.service';

@Component({
  selector: 'app-asset-category-edit',
  templateUrl: './asset-category-edit.component.html',
  styleUrls: ['./asset-category-edit.component.css']
})
export class AssetCategoryEditComponent extends BaseComponent implements OnInit {
  editAssetCategoryForm: FormGroup;
  constructor(public messageService: MessageService,
    private dialogRef: MatDialogRef<AssetCategoryEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AssetCategoryDataModel,
    private masterDataService: MasterDataService,
    private formBuilder: FormBuilder,
    public progressIndicatorService:ProgressIndicatorService) {
    super(messageService);
    this.editAssetCategoryForm = formBuilder.group({
      AssetCategoryName: [data.assetCategoryName, [Validators.required, Validators.maxLength(100)]],
      Description: [data.description, [Validators.required, Validators.maxLength(500)]],
    });
  }

  override ngOnInit(): void {
  }

  onSaveAssetCategory(form: FormGroup) {
    if (form.valid) {
      var value = form.value;
      this.data.assetCategoryName = value.AssetCategoryName;
      this.data.description = value.Description;
      this.data.updatedBy = 0;
      this.masterDataService
        .updateAssetCategory(this.data)
        .subscribe({
          next: (response) => {
            if (response.isSuccess == false) {
              super.handleResponseError(response);
            } else {
              super.showSnackBarInfo(response.responseMessage.message);
              this.dialogRef.close({ event: 'Update' });
            }
          },
          error: (error) => {
            super.showSnackBarError(error);
          }
        });
    }

  }
}