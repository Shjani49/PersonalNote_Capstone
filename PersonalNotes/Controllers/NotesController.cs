using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public Notes CreateNotes(string description, string date)
        {
          /*  DateTime dateParsed = new DateTime();*/
           
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description), "Notes was not provided.");
            }
            else
            {
                description = description.Trim();
            }
            if (string.IsNullOrWhiteSpace(date))
            {
                throw new ArgumentNullException(nameof(date), "Date was not provided.");
            }
            /*else
            {
                date = date.Trim();
                if (!DateTime.TryParse(date, out dateParsed))
                {
                    throw new Exception("Date is not valid.");
                }
                else
                {
                    if (dateParsed > DateTime.Today)
                    {
                        throw new Exception("Date cannot be in future.");
                    }
                   
                }

            }*/
            Notes created = new Notes()
            {
                Description = description,
                Date = DateTime.Parse(date)
              
            };
            using (NoteContext context = new NoteContext())
            {
                context.Notes.Add(created);
                context.SaveChanges();
            }
            return created;
        }
    }
}
