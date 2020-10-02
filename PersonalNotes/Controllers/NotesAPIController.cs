using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Models;


namespace PersonalNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesAPIController : ControllerBase
    {
        [HttpGet("AllNotes")]
        public ActionResult<List<Notes>> AllNotes()
        {
            // TODO: Catch for unable to connect to database.
            // Return the response.
            return new NotesController().GetNotes();
        }
    }
}
