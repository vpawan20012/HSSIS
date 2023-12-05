using HSSIS.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace HSSIS.Models.DataModels
{
    [Table("TBL_Master_AssetCategory")]
    [PrimaryKey("AssetCategoryId")]
    public class AssetCategoryModel:BaseDataModel
    {        
        public int AssetCategoryId { get; set; }
        public string AssetCategoryName { get; set; }
        public string Description { get; set; }
    }
}
