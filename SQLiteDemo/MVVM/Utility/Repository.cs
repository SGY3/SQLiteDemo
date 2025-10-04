using SQLite;
using SQLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.MVVM.Utility
{
    public class Repository
    {
        SQLiteConnection conn;
        public Repository()
        {
            conn = new SQLiteConnection(DbConnection.DbPath, DbConnection.Flags);
            conn.CreateTable<Item>();
        }
        public void AddItem(Item item)
        {
            int result = 0;
            try
            {
                result = conn.Insert(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Item> GetItems()
        {
            try
            {
                return conn.Table<Item>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Item GetItemById(int id)
        {
            try
            {
                return conn.Table<Item>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateItem(Item item)
        {
            int result = 0;
            try
            {
                result = conn.Update(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteItem(int id)
        {
            int result = 0;
            var item = GetItemById(id);
            try
            {
                result = conn.Delete(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
