using System;
using System.Threading.Tasks;
using Librabobus.Backend.Dtos;
using Librabobus.Backend.Dtos.Record;
using Librabobus.Backend.Dtos.User;
using Librabobus.Backend.Models.Record;
using Librabobus.Backend.Models.User;
using Librabobus.Backend.Repositories.Api;
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
        /// Получить запись по id.
        /// </summary>
        /// <response code="200">Получена запись.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation("Получить запись по id.")]
        [SwaggerResponse(statusCode: 200, type: typeof(RecordDto), description: "Получена запись.")]
        [SwaggerResponse(statusCode: 500, type: typeof(EmptyResult), description: "Ошибка на стороне сервера.")]

        public async Task<IActionResult> GetRecordById(Guid id)
        {
            IActionResult response;
            try
            {
                var record = _recordConverter.Convert(await _recordRepository.GetRecordAsync(id));
                response = Ok(record);
            }
            catch(Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
            return response;
        }
        
        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <response code="200">Запись создана.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPost]
        [Route("")]
        public Task<IActionResult> CreateRecord()
        {
            throw new NotImplementedException();
        }
        
        /// Обновить запись.
        /// </summary>
        /// <response code="200">Запись обновлена.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPut]
        [Route("{id:guid}")]
        public Task<IActionResult> UpdateRecord(Guid id)
        {
            throw new NotImplementedException();
        }
        
        /// Удалить запись.
        /// </summary>
        /// <response code="200">Запись обновлена.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpDelete]
        [Route("{id:guid}")]
        public Task<IActionResult> DeleteRecord(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}