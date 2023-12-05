using HSSIS.Core.Enums;
using HSSIS.Models.ViewModels;
using HSSIS.Repository.AssetCategory;

namespace HSSIS.Business;
public class BusinessManagerBase
{
    protected IAssetCategoryRepository assetCategoryRepository;

    protected void HandleException(Exception ex, IHttpResponseViewModel response)
    {
        //this.GetExceptionHandler().HandleException(ex);Log exception
        response.ResponseMessage = new HttpResposneMessageModel()
        {
            Title = "Error",
            Message = ex.Message,
            Details = ex.ToString(),
            ResponseCancelType = Core.Enums.ResponseMessageCancelTypeEnum.ManualClose,
            MessageDisplayType = ResponseMessageDisplayTypeEnum.PopupMessage
        };
        response.IsSuccess = false;
        //response.ResponseCancelType = Core.Enums.ResponseMessageCancelTypeEnum.ManualClose;
        //return response;
    }
}
