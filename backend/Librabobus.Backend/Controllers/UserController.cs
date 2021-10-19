using System;
using System.Threading.Tasks;
using Librabobus.Backend.Dtos;
using Librabobus.Backend.Dtos.User;
using Librabobus.Backend.Models.User;
using Librabobus.Backend.Repositories.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Librabobus.Backend.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        readonly private IUserRepository _userRepository;
        readonly private IDtoConverter<UserPageModel, UserPageDto> _userPageConverter;

        public UserController(IUserRepository userRepository,
            IDtoConverter<UserPageModel, UserPageDto> userPageConverter)
        {
            _userRepository = userRepository;
            _userPageConverter = userPageConverter;
        }
        
        /// <summary>
        /// Получить страницу пользователя по id.
        /// </summary>
        /// <response code="200">Получена страница.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUserPage(Guid id)
        {
            IActionResult response;
            try
            {
                var userPage = _userPageConverter.Convert(await _userRepository.GetUserPageAsync(id));
                response = Ok(userPage);
            }
            catch(Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
            return response;
        }

    }
}