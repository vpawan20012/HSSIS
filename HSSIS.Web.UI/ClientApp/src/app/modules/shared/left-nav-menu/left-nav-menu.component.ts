import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';
import { MatNavList } from '@angular/material/list';
import { MatListItem } from '@angular/material/list';
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
