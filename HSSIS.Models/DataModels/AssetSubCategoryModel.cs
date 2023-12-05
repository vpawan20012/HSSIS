using HSSIS.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Models.DataModels
{
    [Table("TBL_Master_AssetSubCategory")]
    [PrimaryKey("AssetSubCategoryId")]
    public class AssetSubCategoryModel : BaseDataModel
    {
        public int AssetSubCategoryId { get; set; }
        public int AssetCategoryId { get; set; }
        public string AssetSubCategoryName { get; set; }
        public string Description { get; set; }
    }
}
