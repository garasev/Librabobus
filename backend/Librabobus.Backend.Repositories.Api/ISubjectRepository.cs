using System;
using System.Threading.Tasks;
using Librabobus.Backend.Models.Subject;
using System.Collections.Generic;

namespace Librabobus.Backend.Repositories.Api
{
    public interface ISubjectRepository
    {
        /// <summary>
        /// Поиск предмета по id
        /// </summary>
        /// <param name="id">Id предмета</param>
        /// <returns>Модель предмета</returns>
        Task<SubjectModel> FindSubjectAsync(Guid id);
        
        /// <summary>
        /// Получение списка моделей предметов
        /// </summary>
        /// <returns>Список моделей предметов</returns>
        Task<List<SubjectModel>> FindAllSubjectAsync();
        
        /// <summary>
        /// Добавление предмета
        /// </summary>
        /// <param name="subjectModel">Новая модель предмета</param>
        /// <returns>Модель предмета</returns>
        Task<SubjectModel> AddSubjectAsync(SubjectModel subjectModel);
        
        /// <summary>
        /// Изменение предмета
        /// </summary>
        /// <param name="updateSubjectModel">Модель предмета</param>
        /// <exception cref="NotFoundException">Предмета с данным id не найдена.</exception>
        /// <returns>Обновленная модель предмета</returns>
        Task<SubjectModel> UpdateSubjectAsync(SubjectModel updateSubjectModel);
        
        /// <summary>
        /// Удаление предмета
        /// </summary>
        /// <param name="id">Id предмета</param>
        /// <returns>Удаленная модель предмета</returns>
        Task<SubjectModel> DeleteSubjectAsync(Guid id);
    }
}