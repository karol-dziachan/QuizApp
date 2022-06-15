using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Domain.Entity;

namespace QuizApp.App.Abtract
{
    public interface IService<T> 
    {
        List<T> Items { get; set; }

        List<T> GetAllItems();
        int GetLastId();
        T GetItemById(int id);
        int AddItem(T item);
        int UpdateItem(T item);
        int RemoveItem(T item);
        List<int> GetAllIds();
    }
}
