using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Repository.Repository
{
    public class BaseRepository
    {
        protected readonly MovieDataContext _context;
        protected bool disposed = false;

        public BaseRepository(MovieDataContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
