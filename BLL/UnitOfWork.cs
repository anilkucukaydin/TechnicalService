using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork
    {
        public ServiceContext db;
        public BaseRepository<Fault, int> Faults;
        public BaseRepository<LiveMessage, int> LiveMessages;
        public UnitOfWork()
        {

            if (db == null)
                db = new ServiceContext();
            Faults = new BaseRepository<Fault, int>(db);
            LiveMessages = new BaseRepository<LiveMessage, int>(db);
        }


        public static ServiceContext Create()
        {
            return new ServiceContext();
        }

        public bool Complete()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}



