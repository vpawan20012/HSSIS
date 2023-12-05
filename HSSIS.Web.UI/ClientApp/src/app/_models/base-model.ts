export interface BaseModel
{
    createdBy?:number;
    updatedBy?:number;
    createdDate?:Date;
    updatedDate?:Date;
    deleteFlag?:boolean;
    isActive?:boolean;
}