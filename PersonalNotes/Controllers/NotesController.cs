using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalNotes.Models;

namespace PersonalNotes.Controllers
{
    public class NotesController : Controller
    {
       
        public List<Notes> GetNotes()
        {
            List<Notes> notes;
            using (NoteContext context = new NoteContext())
            {
                notes = context.Notes.ToList();
            }
            return notes;
        }
    }
}
