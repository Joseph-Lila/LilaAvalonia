using System;
using System.Collections.Generic;
using Lila.DAL.Entities;


namespace Lila.DAL.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetCollection(); //получение коллекции объектов
        T GetItem(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T old, T @new); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save(); // сохранение изменений
    }
}
