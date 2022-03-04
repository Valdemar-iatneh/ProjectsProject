using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using ProjectsProject.Database.Model;

namespace ProjectsProject.Database
{
    class DBRepository
    {
        SQLiteConnection db;
        public DBRepository(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Image>();
        }

        public IEnumerable<Image> GetItems()
        {
            return db.Table<Image>().ToList();
        }

        public Image GetItem(int id)
        {
            return db.Get<Image>(id);
        }

        public int DeleteItem(int id)
        {
            return db.Delete<Image>(id);
        }

        public int SaveItem(Image item)
        {
            if (item.Id != 0)
            {
                db.Update(item);
                return item.Id;
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
