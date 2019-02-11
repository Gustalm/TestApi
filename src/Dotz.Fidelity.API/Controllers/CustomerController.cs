using Dotz.Fidelity.API.Requests;
using Dotz.Fidelity.Application.Command.Commands;
using Dotz.Fidelity.CrossCutting;
using Dotz.Fidelity.CrossCutting.Options;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelity.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AuthOptions _authOptions;

        public CustomerController(IMediator mediator, IOptions<AuthOptions> authOptions)
        {
            this._mediator = mediator;
            _authOptions = authOptions.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticationRequest request)
        {
            var result = await _mediator.Send(new AuthenticateCustomerCommand(){ Email = request.Email, Password = request.Password });

            if (result.IsFailure)
                return BadRequest(result);

            var customer = result.Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customer.Cpf.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = customer.Id,
                Username = customer.Name,
                FirstName = customer.Cpf,
                LastName = customer.Email,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Authenticate(RegisterCustomerCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.IsFailure)
                return BadRequest(result);

            return Created("uma url aqui", result.Value);
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
