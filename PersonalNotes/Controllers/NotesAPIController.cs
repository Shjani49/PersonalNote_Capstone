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

        [HttpPost("CreateNotes")]
        public ActionResult<Notes> CreateNote(string description, string date)
        {
            ActionResult<Notes> response;
            Notes created;
            try
            {
                // We aren't concerned with validation here. Only in BLL.
                created = new NotesController().CreateNotes(description,date);
                // Encode our created object as JSON and bounce it back with the request.
                response = Ok(created);
            }
            catch (InvalidOperationException)
            {
                response = StatusCode(403, new { error = $"Notes was not Provided." });
            }
            catch (Exception e)
            {
                response = StatusCode(403, new { error = e.Message }); 
            }


            // Return the response.
            return response;
        }



    }
}
