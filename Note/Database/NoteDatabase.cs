using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Note
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection db;

        public NoteDatabase(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return db.UpdateAsync(note);
            }
            else
            {
                return db.InsertAsync(note);
            }
        }

        public Task<int> DeletNoteAsync(Note note)
        {
            return db.DeleteAsync(note);
        }
    }
}
