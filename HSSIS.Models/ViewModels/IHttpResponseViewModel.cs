using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Models.ViewModels
{
    public interface IHttpResponseViewModel
    {
        bool IsSuccess { get; set; }
        HttpResposneMessageModel ResponseMessage { get; set; }
    }
}
