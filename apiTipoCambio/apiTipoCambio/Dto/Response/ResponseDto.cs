using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Dto.Response
{
    public class ResponseDto
    {
        public string ResStatus { get; set; }
        public List<ResponseErrorDto> ResError { get; set; }
        public object ResResult { get; set; }
    }
}
