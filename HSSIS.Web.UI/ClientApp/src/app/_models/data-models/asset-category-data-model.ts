import { BaseViewModel } from "../view-models/base-view-model";
import { BaseDataModel } from "./base-data-model";

export interface AssetCategoryDataModel extends BaseDataModel {
    assetCategoryId?: number;
    assetCategoryName?: string;
    description?: string;
}