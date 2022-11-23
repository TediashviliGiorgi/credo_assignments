using BookLibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;
using System.Xml.Linq;
using System;

namespace BookLibraryAPI.Controllers
{
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private static List<Shelf> shelves = new List<Shelf>();
            

        [HttpGet]
        [Route("getShelves")]
        public async Task<ActionResult<Shelf>> GetShelves()
        {
            
            return Ok(shelves);
        }

        [HttpGet]
        [Route("getShef")]
        public async Task<ActionResult<Shelf>> GetShelf(int id)
        {
            var shelf = shelves.Find(x => x.Id == id);
            if(shelf != null)
            {
                return Ok(shelf);
            }
            else
            {
                return BadRequest("Shelf not found");
            }
        }

        [HttpPost]
        [Route("AddShelf")]
        public async Task<ActionResult<Shelf>> AddShelf(Shelf request)
        {
            var shelf = shelves.Find(x => x.Id == request.Id);
            if(shelf != null)
            {
                return BadRequest("can't add because shelf for this id already exists");
            }
            shelves.Add(request);
            return Ok(shelves);
        }

        [HttpPut]
        [Route("UpdateShelf")]
        public async Task<ActionResult<Shelf>> UpdateShelf(Shelf request)
        {
            var shelf = shelves.Find(x => x.Id == request.Id);
            if (shelf != null)
            {
                shelf.Name = request.Name;
                return Ok(shelf);
            }
            else
            {
                return BadRequest("No shelf found for updating");
            }
        }

        [HttpDelete]
        [Route("deleteShelf")]
        public async Task<ActionResult<Shelf>> DeleteShelf(int id)
        {
            var shelf = shelves.Find(x => x.Id == id);
            if (shelf == null)
            {
                return BadRequest("no shelf found");
            }
            else if (shelf.Books.Count != 0)
            {
                return BadRequest("Can't be delete becouse shelf isn't empty");
            }
            else
            {
                shelves.Remove(shelf);
            }
            return Ok(shelves);
        }

        #region books
        [HttpPost]
        [Route("addToShelf")]
        public async Task<ActionResult<Shelf>> AddToShelf(Book request)
        {
            var shelf = shelves.Find(x => x.Id == request.ShelfId);
            if (shelf != null)
            {
                shelf.Books.Add(request);
            }
            else
            {
                return BadRequest($"can't add book because shelf with id {request.ShelfId} no found");
            }
            return Ok(shelves);
        }

        [HttpPut]
        [Route("moveToShelf")]
        public async Task<ActionResult<Shelf>> MoveToShelf(int shelfId, int bookId, int targetShelfId )
        {
            var shelf = shelves.Find(x => x.Id == shelfId);
            if (shelf != null)
            {
                var book = shelf.Books.Find(x => x.Id == bookId);
                if(book != null && targetShelfId <= shelves.Count)
                {
                    book.ShelfId = shelfId;
                    shelf.Books.Add(book);
                    return Ok(shelves);
                }
                else
                {
                    return BadRequest("no book or target shelf found");
                }
            }
            return Ok(shelves);
        }

        [HttpDelete]
        [Route("removeFromShelf")]
        public async Task<ActionResult<Shelf>> RemoveFromShelf(int shelfId, int bookId)
        {
            var shelf = shelves.Find(x => x.Id == shelfId);
            if (shelf != null)
            {
                var book = shelf.Books.Find(x => x.Id == bookId);
                if(book != null)
                {
                    shelf.Books.Remove(book);
                }
            }
            else
            {
                return BadRequest($"can't delete book because shelf with id {shelfId} or book with id {bookId} no found");
            }
            return Ok(shelves);
        }

        #endregion
    }
}