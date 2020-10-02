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

            DateTime dateParsed;

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description), "Note Description was not provided.");
            }
            else
            {
                description = description.Trim();
            }

            if (string.IsNullOrWhiteSpace(date))
            {
                throw new ArgumentNullException(nameof(date), "Date was not provided.");
            }
            else
            {
                date = date.Trim();
                if (!DateTime.TryParse(date, out dateParsed))
                {
                    throw new ArgumentException("Date is not valid.", nameof(date));
                }
                else
                {
                    if (dateParsed > DateTime.Today)
                    {
                        throw new ArgumentException("Date can not be in past.", nameof(date));
                    }
                }
            }

            Notes newNote = new Notes()
            {
                Description = description,
                Date = dateParsed
            };

            using (NoteContext context = new NoteContext())
            {
                context.Notes.Add(newNote);
                context.SaveChanges();
            }

            return newNote;
        }
    }
}