import { BaseViewModel } from "../view-models/base-view-model";
import { BaseDataModel } from "./base-data-model";

export interface AssetSubCategoryDataModel extends BaseDataModel {
    assetSubCategoryId?: number;
    assetCategoryId?: number;
    assetSubCategoryName?: string;
    description?: string;
}