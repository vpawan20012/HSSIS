import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResponseMessageDisplayTypeEnum, ResponseMessageTypeEnum } from 'src/app/_enums/common-enums';
import { HttpResponseModel } from 'src/app/_models/view-models/http-response-view-model';
import { environment } from 'src/environments/environment';
import swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private _snackBar: MatSnackBar) { }

  showResponseErrorMessage(responseMessage: any) {
    //console.log(responseMessage);
    var showErrorDetails = `${environment.showErrorDetails}`;
    //console.log(showErrorDetails);
    if (showErrorDetails == 'true' && responseMessage.details != null) {
      return swal.fire({
        icon: 'error',
        title: responseMessage.title,
        html: '<div>' + responseMessage.message + '</div><div class="message-details">' + responseMessage.details + '</div>'
      });
    }
    else {
      return swal.fire({
        icon: 'error',
        title: responseMessage.title,
        text: responseMessage.message
      });
    }
  }

  showMessage(title: string, message: string, icon: any) {
    return swal.fire({
      icon: icon,
      title: title,
      text: message
    });
  }

  showConfirmationMessage(title: string, message: string, confirmButtonText: string, icon: any) {
    if (icon == null) {
      icon = 'question';
    }
    return swal.fire({
      title: title,
      text: message,
      icon: icon,
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: confirmButtonText
    });
  }

  showSnack_Error(message: string) {
    return this._snackBar.open(message, undefined, { panelClass: 'snackbar-error', duration: 5000 });
  }

  showSnack_success(message: string) {
    return this._snackBar.open(message, undefined, { panelClass: ['snackbar-success'], duration: 5000 });
  }

  showSnack_info(message: string) {
    return this._snackBar.open(message, undefined, { panelClass: ['snackbar-info'], duration: 5000 });
  }

  showSnack_warning(message: string) {
    return this._snackBar.open(message, undefined, { panelClass: ['snackbar-warn'], duration: 5000 });
  }

  showActionResponseMessage(response: HttpResponseModel) {
    //messageDisplayType: SnackBarMessage=0,PopupMessage=1
    //responseType: Undefined = 0,Success = 1,Error = 2,Warning = 3,Fail = 4,ValidationFailed=5    
    if (response.responseMessage?.messageDisplayType == ResponseMessageDisplayTypeEnum.SnackBarMessage) {
      if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Success) {
        return this.showSnack_success(response.responseMessage.message);
      }
      else if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Error
        || response.responseMessage?.responseType == ResponseMessageTypeEnum.Fail
        || response.responseMessage?.responseType == ResponseMessageTypeEnum.ValidationFailed) {
        return this.showSnack_Error(response.responseMessage.message);
      }
      else if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Warning) {
        return this.showSnack_warning(response.responseMessage.message);
      }
      else if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Information) {
        return this.showSnack_info(response.responseMessage.message);
      }
      else {
        return this.showSnack_info(response.responseMessage.message);
      }
    }
    else {
      //icons: success, error,warning,info,question
      var icon: SweetAlertIcon | undefined = 'info';
      if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Success) {
        icon = 'success';
      }
      else if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Error
        || response.responseMessage?.responseType == ResponseMessageTypeEnum.Fail
        || response.responseMessage?.responseType == ResponseMessageTypeEnum.ValidationFailed) {
        icon = 'error';
      }
      else if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Warning) {
        icon = 'warning';
      }
      else if (response.responseMessage?.responseType == ResponseMessageTypeEnum.Undefined
        || response.responseMessage?.responseType == ResponseMessageTypeEnum.Information) {
        icon = 'info';
      }
      return swal.fire({
        icon: icon,
        title: response.responseMessage?.title,
        text: response.responseMessage?.message
      });
    }
  }
}