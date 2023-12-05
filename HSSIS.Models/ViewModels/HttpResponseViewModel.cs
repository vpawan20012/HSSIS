using HSSIS.Core.Enums;
using HSSIS.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Models.ViewModels
{
    public class HttpResponseViewModel<T>:IHttpResponseViewModel
    {
        private T? result;
        public bool IsSuccess { get; set; }
        public T? Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }
        public HttpResposneMessageModel ResponseMessage { get; set; }
        public HttpResponseViewModel()
        {
            this.IsSuccess = true;            
            this.ResponseMessage = new HttpResposneMessageModel()
            {
                ResponseCancelType = ResponseMessageCancelTypeEnum.AutoClose,
                ResponseType = ResponseMessageTypeEnum.Success
            };
        }
    }

    public class HttpResposneMessageModel
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public ResponseMessageTypeEnum ResponseType { get; set; }
        public ResponseMessageDisplayTypeEnum MessageDisplayType { get; set; }
        public ResponseMessageCancelTypeEnum ResponseCancelType { get; set; }
        //public string? ErrorMessage { get; set; }

    }
}
