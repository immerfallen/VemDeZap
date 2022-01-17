using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VemDeZap.Domain.Commands;
using VemDeZap.Infra.Repositories.Transactions;

namespace VemDeZap.Api.Controllers.Base
{
   
    public class ControllerBase  : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(AutenticarUsuarioResponse response)
        {
            if (!response.Notifications.Any())
            {
                try
                {
                    _unitOfWork.SaveChanges();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema com o servidor. Entre em contato com o administrador dos sistema caso o erro persista.");
                }
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
