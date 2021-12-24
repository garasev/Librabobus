using System;
using System.Threading.Tasks;
using System.Linq;
using Librabobus.Backend.Dtos;
using Librabobus.Backend.Dtos.Record;
using System.Collections.Generic;
using Librabobus.Backend.Dtos.User;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Models.User;
using Librabobus.Backend.Repositories.Api;
using Librabobus.Backend.Repositories.Impl.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Librabobus.Backend.Controllers
{
    [Route("records")]
    [ApiController]
    public class RecordController: ControllerBase
    {
        readonly private IRecordRepository _recordRepository;
        readonly private IDtoConverter<RecordModel, RecordDto> _recordConverter;

        public RecordController(IRecordRepository recordRepository,
            IDtoConverter<RecordModel, RecordDto> recordConverter)
        {
            _recordRepository = recordRepository;
            _recordConverter = recordConverter;
        }
        
        /// <summary>
        /// Получить все записи.
        /// </summary>
        /// <response code="200">Получены все записии.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [Authorize]
        [HttpGet]
        [SwaggerOperation("Получить все записи.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(List<RecordDto>), description: "Получены все записи.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetRecords()
        {
            IActionResult response;
            try
            {
                var records = await _recordRepository.FindAllRecordAsync();
                response = Ok(records.Select(record => _recordConverter.Convert(record)).ToArray());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        
        /// <summary>
        /// Получить все записи по id предмета.
        /// </summary>
        /// <response code="200">Получены все записии.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [Authorize]
        [HttpGet]
        [Route("/sub/{subId:guid}")]
        [SwaggerOperation("Получить все записи по id предмета.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(List<RecordDto>), description: "Получены все записи.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetSubRecords(Guid subId)
        {
            IActionResult response;
            try
            {
                var records = await _recordRepository.FindAllRecordAsync();
                response = Ok(records.Select(record => _recordConverter.Convert(record)).Where(record => record.SubjectId == subId).ToArray());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        
        /// <summary>
        /// Получить запись по id.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        /// <response code="200">Получена запись с необходимым id.</response>
        /// <response code="404">Запись с указанным id не найдена.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation("Получить запись по id.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(RecordDto), description: "Получена запись с необходимым id.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(EmptyResult), description: "Запись с указанным id не найдена.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> GetRecordById(Guid id)
        {
            IActionResult response;
            try
            {
                var record = await _recordRepository.FindRecordAsync(id);
                if (record == null!)
                {
                    response = NotFound("Category with such Id: {id} not found.");
                }
                else
                {
                    response = Ok(_recordConverter.Convert(record));
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Добавить запись.
        /// </summary>
        /// <param name="recordDto">Dto новой записи</param>
        /// <response code="200">Запись успешно добавлена.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPost]
        [SwaggerOperation("Добавить категорию.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(RecordDto), description: "Запись успешно добавлена.")]
        [SwaggerResponse(statusCode: StatusCodes.Status409Conflict, type: typeof(EmptyResult), description: "Параметры не прошли проверку на уникальность.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> PostRecord([FromBody] RecordDto recordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            IActionResult response;
            try
            {
                var record = await _recordRepository.AddRecordAsync(_recordConverter.Convert(recordDto));
                response = Ok(_recordConverter.Convert(record));
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
        /// Изменить существующую запись.
        /// </summary>
        /// <param name="id">Id изменяемой записи.</param>
        /// <param name="recordDto">Измененный dto записи.</param>
        /// <response code="200">Запись успешно изменена.</response>
        /// <response code="400">Параметры не прошли проверку.</response>
        /// <response code="404">Запись не найдена.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPut]
        [Route("{id:guid}")]
        [SwaggerOperation("Изменить существующую запись.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(RecordDto), description: "Запись успешно изменена.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, type: typeof(EmptyResult), description: "Параметры не прошли проверку.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, type: typeof(EmptyResult), description: "Запись не найдена.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> PutRecord(Guid id, [FromBody] RecordDto recordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            IActionResult response;
            try
            {
                var record = await _recordRepository.UpdateRecordAsync(_recordConverter.Convert(recordDto));
                response = Ok(_recordConverter.Convert(record));
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
        /// Удалить существующую запись.
        /// </summary>
        /// <param name="id">Id удаляемой записи.</param>
        /// <response code="200">Запись успешно удалена.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation("Удалить существующую запись.")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(RecordDto), description: "Запись успешно удалена.")]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]
        public async Task<IActionResult> DeleteRecord(Guid id)
        {
            IActionResult response;
            try
            {
                var record = await _recordRepository.DeleteRecordAsync(id);
                response = Ok(_recordConverter.Convert(record));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}