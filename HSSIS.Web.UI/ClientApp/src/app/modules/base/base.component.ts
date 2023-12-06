import { Component, OnInit } from '@angular/core';
import { HttpResponseModel } from 'src/app/_models/view-models/http-response-view-model';
import { MessageService } from 'src/app/services/core-services/message-service/message.service';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent implements OnInit {

  constructor(public messageService:MessageService) { }

  ngOnInit(): void {
  }

  showErrorMessage(error: any) {
    this.messageService.showMessage('Error', error, 'error');
  }

  handleResponseError(responseMessage: any) {
    this.messageService.showResponseErrorMessage(responseMessage.responseMessage);
  }

  showConfirmationMessage(title: string, message: string, confirmButtonText: string, icon: any) {
    return this.messageService.showConfirmationMessage(title, message, confirmButtonText, icon);
  }

  showSnackBarError(message: string) {
    this.messageService.showSnack_Error(message);
  }

  showSnackBarInfo(message: string) {
    this.messageService.showSnack_info(message);
  }

  showSnackBarSucces(message: string) {
    this.messageService.showSnack_success(message);
  }

  handleActionResponseMessage(response: HttpResponseModel) {
    return this.messageService.showActionResponseMessage(response);
  }

  handleResponseMessage(responseMessage: any) {
    this.messageService.showSnack_success(responseMessage.responseMessage);
  }
}
