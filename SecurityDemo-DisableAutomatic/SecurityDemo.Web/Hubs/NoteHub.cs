using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SecurityDemo.Web.Models;

namespace SecurityDemo.Web.Hubs
{
    public class NoteHub : Hub
    {
        private static List<Note> NoteList { get; set; }
        static NoteHub()
        {
            NoteList = new List<Note>();
        }

        public List<Note> GetNotes()
        {
            return NoteList;
        }

        [Authorize]
        public void AddNote(Note newNote)
        {
            newNote.Date = DateTime.Now;
            newNote.Author = Context.User.Identity.Name;
            NoteList.Add(newNote);

            Clients.All.IncomingNote(newNote);
        }
        
        [Authorize(Roles="Admin")]
        public void DeleteAllNotes()
        {
            NoteList.Clear();
        }
    }
}