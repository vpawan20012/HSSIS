import { Component, Input, OnInit } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ProgressIndicatorService } from 'src/app/services/core-services/progress-indicator-service/progress.indicator.service';

@Component({
  selector: 'app-popup-header',
  templateUrl: './popup-header.component.html',
  styleUrls: ['./popup-header.component.css']
})
export class PopupHeaderComponent extends BaseComponent implements OnInit {
  @Input() title: string = '';
  @Input() showProgressIndicator: boolean = true;
  @Input() showCloseButton: boolean = true;
  constructor(messageService: MessageService,
    public progressIndicatorService: ProgressIndicatorService) {
    super(messageService);
  }

  override ngOnInit(): void {
  }

}
