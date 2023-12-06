export interface HttpResponseModel
{
    isSuccess?:boolean;
    responseMessage?:ResposneMessageModel;
}

export interface ResposneMessageModel
{
    title:string;
    message:string;
    details?:string;
    responseType?:number;
    messageDisplayType?:number;
    responseCancelType?:number;
}