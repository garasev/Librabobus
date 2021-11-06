using System;
using System.Threading.Tasks;
using Librabobus.Backend.Models.Record;
using System.Collections.Generic;

namespace Librabobus.Backend.Repositories.Api
{
    public interface IRecordRepository
    {
        /// <summary>
        /// Поиск записи по id
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <returns>Модель записи</returns>
        Task<RecordModel> FindRecordAsync(Guid id);
        
        /// <summary>
        /// Получение списка моделей записей
        /// </summary>
        /// <returns>Список моделей записей</returns>
        Task<List<RecordModel>> FindAllRecordAsync();
        
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="recordModel">Новая модель записи</param>
        /// <returns>Модель записи</returns>
        Task<RecordModel> AddRecordAsync(RecordModel recordModel);
        
        /// <summary>
        /// Изменение записи
        /// </summary>
        /// <param name="updateRecordModel">Модель записи</param>
        /// <exception cref="NotFoundException">Записи с данным id не найдена.</exception>
        /// <returns>Обновленная модель записи</returns>
        Task<RecordModel> UpdateRecordAsync(RecordModel updateRecordModel);
        
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <returns>Удаленная модель записи</returns>
        Task<RecordModel> DeleteRecordAsync(Guid id);
    }
}