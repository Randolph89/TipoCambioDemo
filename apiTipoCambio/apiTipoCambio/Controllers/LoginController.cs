﻿using apiTipoCambio.Dto.Login;
using apiTipoCambio.Helpers;
using apiTipoCambio.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _iLoginService;
        private readonly IMapper _mapper;
        public LoginController(IConfiguration configuration, ILoginService iLoginService, IMapper mapper)
        {
            _configuration = configuration;
            _iLoginService = iLoginService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UsuarioLoginDto model)
        {
            var oUsuarioLoginDto = await _iLoginService.GetLogin(model.UsuarioId, model.Contrasenia);

            var oUsuarioDto = _mapper.Map<UsuarioDto>(oUsuarioLoginDto);

            if (!string.IsNullOrEmpty(oUsuarioLoginDto.UsuarioId))
            {
                var oJwtHelper = new JwtHelper(_configuration);
                return Ok(oJwtHelper.BuildToken(oUsuarioDto));
            }
            else
            {
                return BadRequest("Username or password invalid");
            }

        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
