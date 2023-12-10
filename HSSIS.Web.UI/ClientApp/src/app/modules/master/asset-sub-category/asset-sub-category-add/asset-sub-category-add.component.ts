import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/modules/base/base.component';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';

@Component({
  selector: 'app-asset-sub-category-add',
  templateUrl: './asset-sub-category-add.component.html',
  styleUrls: ['./asset-sub-category-add.component.css']
})
export class AssetSubCategoryAddComponent extends BaseComponent implements OnInit {

  constructor(messageService: MessageService) {
    super(messageService);
  }

  override ngOnInit(): void {
  }

}
