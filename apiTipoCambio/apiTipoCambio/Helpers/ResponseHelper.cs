﻿using apiTipoCambio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Helpers
{
    public class ResponseHelper
    {
        public ResponseDto GenerarResponse500(ResponseErrorDto pResponseModelError)
        {
            var vListaResponseError = new List<ResponseErrorDto> { pResponseModelError };
            var oResponseModel = new ResponseDto()
            {
                ResStatus = Constantes.Constantes.ResultadoSistema.Error,
                ResError = vListaResponseError
            };
            return oResponseModel;
        }

        public ResponseDto GenerarResponseBadResquest(ResponseErrorDto pResponseModelError)
        {
            var vListaResponseError = new List<ResponseErrorDto> { pResponseModelError };
            var oResponseModel = new ResponseDto()
            {
                ResStatus = Constantes.Constantes.ResultadoSistema.BadResquest,
                ResError = vListaResponseError
            };
            return oResponseModel;
        }
    }
}
