﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Dto.Response
{
    public class ResponseErrorDto
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string CodeLine { get; set; }
        public string TracingId { get; set; }
    }
}
