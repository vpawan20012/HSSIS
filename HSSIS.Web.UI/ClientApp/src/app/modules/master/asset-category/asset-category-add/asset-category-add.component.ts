import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AssetCategoryDataModel } from 'src/app/_models/data-models/asset-category-data-model';
import { BaseComponent } from 'src/app/modules/base/base.component';
import { MasterDataService } from 'src/app/services/app-services/master-data/master-data.service';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';

@Component({
  selector: 'app-asset-category-add',
  templateUrl: './asset-category-add.component.html',
  styleUrls: ['./asset-category-add.component.css']
})
export class AssetCategoryAddComponent extends BaseComponent implements OnInit {
  newAssetCategoryForm: FormGroup;

  constructor(public messageService: MessageService,
    private formBuilder: FormBuilder,
    private masterDataService: MasterDataService,
    private dialogRef: MatDialogRef<AssetCategoryAddComponent>) {
    super(messageService);
    this.newAssetCategoryForm = formBuilder.group({
      AssetCategoryName: [null, [Validators.required, Validators.maxLength(100)]],
      Description: [null, [Validators.required, Validators.maxLength(500)]],
    });
  }

  override ngOnInit(): void {

  }

  onSaveAssetCategory(form: FormGroup) {
    if (form.valid) {
      var value = form.value;
      const newAssetCategory: AssetCategoryDataModel = {
        assetCategoryName: value.AssetCategoryName,
        description: value.Description,
        createdBy:0
      };
      //console.log(newRoute);
      this.masterDataService
        .addAssetCategory(newAssetCategory)
        .subscribe({
          next: (response) => {
            if (response.isSuccess == false) {
              super.handleResponseError(response);
            } else {
              super.showSnackBarInfo(response.responseMessage.message);
              this.dialogRef.close({ event: 'Add' });
            }
          },
          error: (error) => {
            //super.showSnackBarError(error); 
          }
        });
    }
  }
}
