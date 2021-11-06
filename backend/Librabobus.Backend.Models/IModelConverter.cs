using System;

namespace Librabobus.Backend.Models
{
    /// <summary>
    /// Интерфейс для создания конвертеров DbModelT Б-> Model
    /// </summary>
    /// <typeparam name="ModelT">Класс модели уровня контроллеров</typeparam>
    /// <typeparam name="DbModelT">Класс модели базы данных</typeparam>
    public interface IModelConverter<ModelT, DbModelT>
    {
        /// <summary>
        /// Метод для преобразования модели уровня контроллеров в модель базы данных
        /// </summary>
        /// <param name="model">модель уровня контроллеров</param>
        /// <returns>модель базы данных</returns>
        DbModelT Convert(ModelT model);

        /// <summary>
        /// Метод для преобразования модель базы данных в модель уровня контроллеров
        /// </summary>
        /// <param name="dbModel">модель базы данных</param>
        /// <returns>модель уровня контроллеров</returns>
        ModelT Convert(DbModelT dbModel);
        
    }
}