﻿using Azure;
using HSSIS.Core;
using HSSIS.Core.Enums;
using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
using HSSIS.Repository.AssetCategory;
using HSSIS.Repository.AssetSubCategory;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Business
{
    public class MasterBusinessManager : BusinessManagerBase, IMasterBusinessManager
    {
        #region Constructor
        public MasterBusinessManager(IAssetCategoryRepository assetCategoryRepository, IAssetSubCategoryRepository assetSubCategoryRepository)
        {
            base.AssetCategoryRepository = assetCategoryRepository;
            base.AssetSubCategoryRepository = assetSubCategoryRepository;
        }
        #endregion

        #region Asset Category

        public async Task<HttpResponseViewModel<IList<AssetCategoryModel>>> GetAllAssetCategories(bool showDeactivated)
        {
            HttpResponseViewModel<IList<AssetCategoryModel>> response = new HttpResponseViewModel<IList<AssetCategoryModel>>();
            try
            {
                response.Result = await base.AssetCategoryRepository.GetAllAssetCategories(showDeactivated);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<AssetCategoryModel>> GetAssetCategoryById(int assetCategoryId)
        {
            HttpResponseViewModel<AssetCategoryModel> response = new HttpResponseViewModel<AssetCategoryModel>();
            try
            {
                response.Result = await base.AssetCategoryRepository.GetAssetCategoryById(assetCategoryId);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        //public async Task<HttpResponseViewModel<AssetCategoryModel>> GetAssetCategoryByName(string assetCategoryName)
        //{
        //    HttpResponseViewModel<AssetCategoryModel> response = new HttpResponseViewModel<AssetCategoryModel>();
        //    try
        //    {
        //        response.Result = await base.AssetCategoryRepository.GetAssetCategoryByName(assetCategoryName);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.HandleException(ex, response);
        //    }
        //    return response;
        //}

        public async Task<HttpResponseViewModel<int>> AddAssetCategory(AssetCategoryModel assetCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                this.Valdiate_AssetCategory_AddUpdate(assetCategory, response);
                if (response.IsSuccess)
                {
                    response.Result = await base.AssetCategoryRepository.AddAssetCategory(assetCategory);
                    response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Category was not added" : "Asset Category added successfully";
                    response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                    response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<int>> UpdateAssetCategory(AssetCategoryModel assetCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                this.Valdiate_AssetCategory_AddUpdate(assetCategory, response);
                if (response.IsSuccess)
                {
                    response.Result = await base.AssetCategoryRepository.UpdateAssetCategory(assetCategory);
                    response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Category was not updated" : "Asset Category updated successfully";
                    response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                    response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<int>> DeactivateAssetCategory(AssetCategoryModel assetCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                this.Valdiate_AssetCategory_Deactivate(assetCategory, response);
                if (response.IsSuccess)
                {
                    response.Result = await base.AssetCategoryRepository.DeactivateAssetCategory(assetCategory);
                    response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Category was not deactivated" : "Asset Category deactivated successfully";
                    response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                    response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<int>> ActivateAssetCategory(AssetCategoryModel assetCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                response.Result = await base.AssetCategoryRepository.ActivateAssetCategory(assetCategory);
                response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Category was not activated" : "Asset Category activated successfully";
                response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        private async void Valdiate_AssetCategory_AddUpdate(AssetCategoryModel assetCategory, HttpResponseViewModel<int> response)
        {
            AssetCategoryModel existingAssetCategory = base.AssetCategoryRepository.GetAssetCategoryByName(assetCategory.AssetCategoryName);
            if (existingAssetCategory != null &&
                (assetCategory.AssetCategoryId.IsZero() ||
                (assetCategory.AssetCategoryId.IsNotZero()
                    && assetCategory.AssetCategoryId != existingAssetCategory.AssetCategoryId)))
            {
                response.IsSuccess = false;
                response.ResponseMessage.Message = "Asset category with given Name already exists. Please check.";
                response.ResponseMessage.ResponseType = ResponseMessageTypeEnum.Error;
            }
        }

        private async void Valdiate_AssetCategory_Deactivate(AssetCategoryModel assetCategory, HttpResponseViewModel<int> response)
        {
            //TODO
        }

        #endregion

        #region Asset Sub Category


        public async Task<HttpResponseViewModel<IList<AssetSubCategoryViewModel>>> GetAllAssetSubCategories(int assetCategoryId, bool showDeactivated)
        {
            HttpResponseViewModel<IList<AssetSubCategoryViewModel>> response = new HttpResponseViewModel<IList<AssetSubCategoryViewModel>>();
            try
            {
                response.Result = await base.AssetSubCategoryRepository.GetAllAssetSubCategories(assetCategoryId, showDeactivated);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<AssetSubCategoryModel>> GetAssetSubCategoryById(int assetSubCategoryId)
        {
            HttpResponseViewModel<AssetSubCategoryModel> response = new HttpResponseViewModel<AssetSubCategoryModel>();
            try
            {
                response.Result = await base.AssetSubCategoryRepository.GetAssetSubCategoryById(assetSubCategoryId);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<int>> AddAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                this.Valdiate_AssetSubCategory_AddUpdate(assetSubCategory, response);
                if (response.IsSuccess)
                {
                    response.Result = await base.AssetSubCategoryRepository.AddAssetSubCategory(assetSubCategory);
                    response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Subcategory was not added" : "Asset Subcategory added successfully";
                    response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                    response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<int>> UpdateAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                this.Valdiate_AssetSubCategory_AddUpdate(assetSubCategory, response);
                if (response.IsSuccess)
                {
                    response.Result = await base.AssetSubCategoryRepository.UpdateAssetSubCategory(assetSubCategory);
                    response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Subcategory was not updated" : "Asset Subcategory updated successfully";
                    response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                    response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<int>> DeactivateAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                this.Valdiate_AssetSubCategory_Deactivate(assetSubCategory, response);
                if (response.IsSuccess)
                {
                    response.Result = await base.AssetSubCategoryRepository.DeactivateAssetSubCategory(assetSubCategory);
                    response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Subcategory was not deactivate" : "Asset Subcategory deactivate successfully";
                    response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                    response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<int>> ActivateAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            HttpResponseViewModel<int> response = new HttpResponseViewModel<int>();
            try
            {
                response.Result = await base.AssetSubCategoryRepository.ActivateAssetSubCategory(assetSubCategory);
                response.ResponseMessage.Message = response.Result.IsZero() ? "Asset Subcategory was not activate" : "Asset Subcategory activate successfully";
                response.ResponseMessage.ResponseType = response.Result.IsZero() ? ResponseMessageTypeEnum.Fail : ResponseMessageTypeEnum.Success;
                response.ResponseMessage.ResponseCancelType = response.Result.IsZero() ? ResponseMessageCancelTypeEnum.ManualClose : ResponseMessageCancelTypeEnum.AutoClose;
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        private async void Valdiate_AssetSubCategory_AddUpdate(AssetSubCategoryModel assetSubCategory, HttpResponseViewModel<int> response)
        {
            AssetSubCategoryModel existingAssetSubCategory = base.AssetSubCategoryRepository.GetAssetSubCategoryByName(assetSubCategory.AssetSubCategoryName);
            if (existingAssetSubCategory != null &&
                (assetSubCategory.AssetSubCategoryId.IsZero() ||
                (assetSubCategory.AssetSubCategoryId.IsNotZero()
                    && assetSubCategory.AssetSubCategoryId != existingAssetSubCategory.AssetSubCategoryId)))
            {
                response.IsSuccess = false;
                response.ResponseMessage.Message = "Asset subcategory with given Name already exists. Please check.";
                response.ResponseMessage.ResponseType = ResponseMessageTypeEnum.Error;
            }
        }

        private async void Valdiate_AssetSubCategory_Deactivate(AssetSubCategoryModel assetSubCategory, HttpResponseViewModel<int> response)
        {
            //TODO
        }


        #endregion

    }
}
