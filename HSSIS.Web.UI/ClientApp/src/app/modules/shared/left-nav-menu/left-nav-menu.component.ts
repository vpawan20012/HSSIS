import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';

@Component({
  selector: 'app-left-nav-menu',
  templateUrl: './left-nav-menu.component.html',
  styleUrls: ['./left-nav-menu.component.css']
})
export class LeftNavMenuComponent extends BaseComponent implements OnInit {

  constructor(public messageService: MessageService) {
    super(messageService);
  }

  override ngOnInit(): void {
  }

}
