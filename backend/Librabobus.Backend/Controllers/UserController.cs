using System;
using System.Linq;
using System.Threading.Tasks;
using Librabobus.Backend.Dtos;
using Librabobus.Backend.Dtos.User;
using Librabobus.Backend.Models.User;
using Librabobus.Backend.Repositories.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Librabobus.Backend.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        readonly private IUserRepository _userRepository;
        readonly private IDtoConverter<UserPageModel, UserPageDto> _userPageConverter;
        readonly private IDtoConverter<UserSubModel, UserSubDto> _userSubConverter;
        readonly private IDtoConverter<UserModel, UserDto> _userConverter;
        readonly private IDtoConverter<PatchUserModel, PatchUserDto> _userPatchConverter;

        public UserController(IUserRepository userRepository,
            IDtoConverter<UserPageModel, UserPageDto> userPageConverter,
            IDtoConverter<UserModel, UserDto> userConverter,
            IDtoConverter<PatchUserModel, PatchUserDto> userPatchConverter,
            IDtoConverter<UserSubModel, UserSubDto> userSubConverter)
        {
            _userRepository = userRepository;
            _userPageConverter = userPageConverter;
            _userSubConverter = userSubConverter;
            _userConverter = userConverter;
            _userPatchConverter = userPatchConverter;
        }
        
        /// <summary>
        /// Получить страницу пользователя по id.
        /// </summary>
        /// <response code="200">Получена страница.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation("Получить страницу пользователя по id.")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPageDto), description: "Получена страница.")]
        [SwaggerResponse(statusCode: 500, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]

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
        
        /// <summary>
        /// Получить подписчиков пользователя по id.
        /// </summary>
        /// <response code="200">Получены подписчики.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("{id:guid}/subscribers")]
        [SwaggerOperation("Получить подписчиков пользователя по id.")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPageDto), description: "Получены подписчики.")]
        [SwaggerResponse(statusCode: 500, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetSubscribers(Guid id)
        {
            IActionResult response;
            try
            {
                var subs = await _userRepository.GetSubscribersAsync(id);
                var userSubs = subs.Select(sub => _userSubConverter.Convert(sub));
                response = Ok(userSubs);
            }
            catch(Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
            return response;
        }
        
        /// <summary>
        /// Получить подписки пользователя по id.
        /// </summary>
        /// <response code="200">Получены подписки.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("{id:guid}/subscribtions")]
        [SwaggerOperation("Получить подписки пользователя по id.")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPageDto), description: "Получены подписки.")]
        [SwaggerResponse(statusCode: 500, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetSubscriptions(Guid id)
        {
            IActionResult response;
            try
            {
                var subs = await _userRepository.GetSubscriptionsAsync(id);
                var userSubs = subs.Select(sub => _userSubConverter.Convert(sub));
                response = Ok(userSubs);
            }
            catch(Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
            return response;
        }
        /// <summary>
        /// Зарегистрировать пользователя.
        /// </summary>
        /// <response code="200">Пользователь зарегистрирован.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPost]
        [Route("create")]
        [SwaggerOperation("Зарегистрировать пользователя.")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPageDto), description: "Пользователь зарегистрирован.")]
        [SwaggerResponse(statusCode: 500, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            IActionResult response;
            try
            {
                await _userRepository.AddUserAsync(_userConverter.Convert(userDto));
                response = Ok();
            }
            catch(Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
            return response;
        }
        
        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <response code="200">Пользователи получены.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("users")]
        [SwaggerOperation("Получить всех пользователей.")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPageDto), description: "Пользователи получены.")]
        [SwaggerResponse(statusCode: 500, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetUsers()
        {
            IActionResult response;
            try
            {
                var users = await _userRepository.GetUsersAsync();
                response = Ok(users.Select(user => _userConverter.Convert(user)).ToList());
            }
            catch(Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
            return response;
        }
        
        /// <summary>
        /// Изменить информацию о себе.
        /// </summary>
        /// <response code="200">Информация изменена.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPatch]
        [Route("{id:guid}")]
        [SwaggerOperation("Изменить информацию о себе.")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPageDto), description: "Информация изменена.")]
        [SwaggerResponse(statusCode: 500, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> PatchUser(Guid id, [FromBody] PatchUserDto patchUserDto)
        {
            IActionResult response;
            try
            {
                await _userRepository.PatchUserAsync(id, _userPatchConverter.Convert(patchUserDto));
                response = Ok();
            }
            catch(Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
            return response;
        }
    }
}