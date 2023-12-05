using HSSIS.Business;
using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
using HSSIS.Repository.AssetCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HSSIS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : BaseController
    {
        private readonly IAssetCategoryRepository _assetCategoryRepository;

        public MasterDataController(IAssetCategoryRepository assetCategoryRepository)
        {
            this._assetCategoryRepository = assetCategoryRepository;
        }

        [HttpGet]
        [Route("GetAllAssetCategories")]
        public async Task<ActionResult<HttpResponseViewModel<IList<AssetCategoryModel>>>> GetAllAssetCategories()
        {
            //return Ok(new List<TblMasterAssetCategory>());  
            return Ok(await new MasterBusinessManager(this._assetCategoryRepository).GetAllAssetCategories());
        }

        [HttpGet]
        [Route("Test")]
        public ActionResult<string> Test()
        {
            return "Test";
        }
    }
}
