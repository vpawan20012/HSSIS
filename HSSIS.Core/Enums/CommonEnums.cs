namespace HSSIS.Core.Enums
{
    public enum ResponseMessageTypeEnum
    {
        Undefined = 0,
        Success = 1,
        Error = 2,
        Warning = 3,
        Fail = 4,
        ValidationFailed = 5,
        Information = 6
    }

    public enum ResponseMessageCancelTypeEnum
    {
        AutoClose = 0,
        ManualClose = 1
    }

    public enum ResponseMessageDisplayTypeEnum
    {
        SnackBarMessage = 0,
        PopupMessage = 1
    }
}