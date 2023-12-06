using HSSIS.Business;
using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
using HSSIS.Repository.AssetCategory;
using HSSIS.Repository.AssetSubCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HSSIS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : BaseController
    {
        private readonly IMasterBusinessManager masterBusinessManager;

        public MasterDataController(IAssetCategoryRepository assetCategoryRepository, IAssetSubCategoryRepository assetSubCategoryRepository)
        {
            this.masterBusinessManager = new MasterBusinessManager(assetCategoryRepository, assetSubCategoryRepository);
        }

        #region Asset Category


        [HttpGet]
        [Route("GetAllAssetCategories")]
        public async Task<ActionResult<HttpResponseViewModel<IList<AssetCategoryModel>>>> GetAllAssetCategories(bool showDeactivated)
        {
            return await this.masterBusinessManager.GetAllAssetCategories(showDeactivated);
        }

        //[HttpGet]
        //[Route("GetAssetCategoryByName/{assetCategoryName}")]
        //public async Task<ActionResult<HttpResponseViewModel<AssetCategoryModel>>> GetAssetCategoryByName(string assetCategoryName)
        //{
        //    return await this.masterBusinessManager.GetAssetCategoryByName(assetCategoryName);
        //}

        [HttpGet]
        [Route("GetAssetCategoryById")]
        public async Task<ActionResult<HttpResponseViewModel<AssetCategoryModel>>> GetAssetCategoryById(int assetCategoryId)
        {
            return await this.masterBusinessManager.GetAssetCategoryById(assetCategoryId);
        }

        [HttpPost]
        [Route("AddAssetCategory")]
        public async Task<ActionResult<HttpResponseViewModel<int>>> AddAssetCategory(AssetCategoryModel assetCategory)
        {
            return await this.masterBusinessManager.AddAssetCategory(assetCategory);
        }

        [HttpPost]
        [Route("UpdateAssetCategory")]
        public async Task<ActionResult<HttpResponseViewModel<int>>> UpdateAssetCategory(AssetCategoryModel assetCategory)
        {
            return await this.masterBusinessManager.UpdateAssetCategory(assetCategory);
        }

        [HttpPost]
        [Route("DeactivateAssetCategory")]
        public async Task<ActionResult<HttpResponseViewModel<int>>> DeactivateAssetCategory(AssetCategoryModel assetCategory)
        {
            return await this.masterBusinessManager.DeactivateAssetCategory(assetCategory);
        }

        [HttpPost]
        [Route("ActivateAssetCategory")]
        public async Task<ActionResult<HttpResponseViewModel<int>>> ActivateAssetCategory(AssetCategoryModel assetCategory)
        {
            return await this.masterBusinessManager.ActivateAssetCategory(assetCategory);
        }
        #endregion

        #region Asset Sub Category


        [HttpGet]
        [Route("GetAllAssetSubCategories/{assetCategoryId}")]
        public async Task<ActionResult<HttpResponseViewModel<IList<AssetSubCategoryViewModel>>>> GetAllAssetSubCategories(int assetCategoryId)
        {
            return await this.masterBusinessManager.GetAllAssetSubCategories(assetCategoryId);
        }

        #endregion

        [HttpGet]
        [Route("Test")]
        public ActionResult<string> Test()
        {
            return "Test";
        }
    }
}
