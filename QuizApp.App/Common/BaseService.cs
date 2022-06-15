using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.App.Abtract;
using QuizApp.Domain.Common;

namespace QuizApp.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int GetLastId()
        {
            int lastId;

            if (Items.Any())
            {
                lastId = Items.OrderBy(item => item.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }

            return lastId;
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T>  GetAllItems()
        {
            return Items;
        }

        public T  GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);
            return entity;
        }



        public int  RemoveItem(T item)
        {
            Items.Remove(item);

            return item.Id;
        }

        public int  UpdateItem(T item)
        {
            
            int index = Items.FindIndex(s => s.Id == item.Id);

            if (index != -1)
                Items[index] =  item;
            
            /*var entity = Items.FirstOrDefault(it => it.Id == item.Id);
            if(entity != null)
            {
                entity = item;
            }*/

            return index;
        }

        public List<int> GetAllIds()
        {
            List<int> ids = new List<int>();

            foreach(var item in Items)
            {
                ids.Add(item.Id);
            }

            return ids;

        }
    }
}
