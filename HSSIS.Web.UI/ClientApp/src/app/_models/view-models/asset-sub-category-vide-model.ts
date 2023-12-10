import { AssetSubCategoryDataModel } from "../data-models/asset-sub-category-data-model";

export interface AssetSubCategoryViewModel extends AssetSubCategoryDataModel
{
    assetCategoryName?: string;
}