using System;
using System.Threading.Tasks;
using System.Linq;
using Librabobus.Backend.Dtos;
using Librabobus.Backend.Dtos.Record;
using System.Collections.Generic;
using Librabobus.Backend.Dtos.Subject;
using Librabobus.Backend.Dtos.User;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Models.Subject;
using Librabobus.Backend.Models.User;
using Librabobus.Backend.Repositories.Api;
using Librabobus.Backend.Repositories.Impl.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Librabobus.Backend.Controllers
{
    [Route("subjects")]
    [ApiController]
    public class SubjectController: ControllerBase
    {
        readonly private ISubjectRepository _subjectRepository;
        readonly private IDtoConverter<SubjectModel, SubjectDto> _subjectConverter;

        public SubjectController(ISubjectRepository subjectRepository,
            IDtoConverter<SubjectModel, SubjectDto> subjectConverter)
        {
            _subjectRepository = subjectRepository;
            _subjectConverter = subjectConverter;
        }
        
         /// <summary>
        /// Получить все предметы.
        /// </summary>
        /// <response code="200">Получены все предметы.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [SwaggerOperation("Получить все записи.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(List<SubjectDto>), description: "Получены все предметы.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetSubjects()
        {
            IActionResult response;
            try
            {
                var subjects = await _subjectRepository.FindAllSubjectAsync();
                response = Ok(subjects.Select(subject => _subjectConverter.Convert(subject)).ToArray());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Получить предемет по id.
        /// </summary>
        /// <param name="id">Идентификатор предмета.</param>
        /// <response code="200">Получен предмет с необходимым id.</response>
        /// <response code="404">Предмет с указанным id не найден.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation("Получить предмет по id.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(SubjectDto), description: "Получен предмет с необходимым id.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(EmptyResult), description: "Предмет с указанным id не найден.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetSubjectById(Guid id)
        {
            IActionResult response;
            try
            {
                var subject = await _subjectRepository.FindSubjectAsync(id);
                if (subject == null!)
                {
                    response = NotFound("Category with such Id: {id} not found.");
                }
                else
                {
                    response = Ok(_subjectConverter.Convert(subject));
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Добавить предмет.
        /// </summary>
        /// <param name="subjectDto">Dto нового предмета</param>
        /// <response code="200">Предмет успешно добавлен.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPost]
        [SwaggerOperation("Добавить предмет.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(SubjectDto), description: "Предмет успешно добавлен.")]
        [SwaggerResponse(statusCode: StatusCodes.Status409Conflict, type: typeof(EmptyResult), description: "Параметры не прошли проверку на уникальность.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> PostSubject([FromBody] SubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            IActionResult response;
            try
            {
                var subject = await _subjectRepository.AddSubjectAsync(_subjectConverter.Convert(subjectDto));
                response = Ok(_subjectConverter.Convert(subject));
            }
            catch(RepositoryConflictException ex)
            {
                response = Conflict(ex.Message); 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Изменить существующий предмет.
        /// </summary>
        /// <param name="id">Id изменяемого предмета.</param>
        /// <param name="recordDto">Измененный dto предмета.</param>
        /// <response code="200">Предмет успешно изменен.</response>
        /// <response code="400">Параметры не прошли проверку.</response>
        /// <response code="404">Предмет не найден.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPut]
        [Route("{id:guid}")]
        [SwaggerOperation("Изменить существующий предмет.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(SubjectDto), description: "Предмет успешно изменен.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type: typeof(EmptyResult), description: "Параметры не прошли проверку.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(EmptyResult), description: "Предмет не найден.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> PutSubject(Guid id, [FromBody] SubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            IActionResult response;
            try
            {
                var subject = await _subjectRepository.UpdateSubjectAsync(_subjectConverter.Convert(subjectDto));
                response = Ok(_subjectConverter.Convert(subject));
            }
            catch(NotFoundException ex)
            {
                response = NotFound(ex.Message); 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Удалить существующий предмет.
        /// </summary>
        /// <param name="id">Id удаляемого предмета.</param>
        /// <response code="200">Предмет успешно удален.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation("Удалить существующий предмет.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(RecordDto), description: "Предмет успешно удален.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            IActionResult response;
            try
            {
                var subject = await _subjectRepository.DeleteSubjectAsync(id);
                response = Ok(_subjectConverter.Convert(subject));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}