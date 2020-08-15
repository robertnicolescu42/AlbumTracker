using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumTracker.ModelView;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DBContext;
using DataAccess.ModelRepresentation;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbumTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumTrackerController : ControllerBase
    {
        // GET: api/AlbumTracker
        [HttpGet]
        public List<AlbumTrackerView> Get()
        {
            List<AlbumTrackerView> albumTrackerList = new List<AlbumTrackerView>();

            using (AlbumTrackerDBContext db = new AlbumTrackerDBContext())
            {
                var result = db.AlbumTrackerTable;
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        AlbumTrackerView albumTrackerView = new AlbumTrackerView();
                        albumTrackerView.AlbumID = item.AlbumID;
                        albumTrackerView.AlbumName = item.AlbumName;
                        albumTrackerView.ArtistName = item.ArtistName;
                        albumTrackerView.AlbumDescription = item.AlbumDescription;
                        albumTrackerView.AlbumRating = item.AlbumRating;
                        albumTrackerView.AlbumYear = item.AlbumYear;

                        albumTrackerList.Add(albumTrackerView);
                    }
                }
            }

            return albumTrackerList;

        }

        // GET api/AlbumTracker/5
        [HttpGet("{id}")]
        public AlbumTrackerView Get(int id)
        {
            if (id > 0)
            {
                using (AlbumTrackerDBContext db = new AlbumTrackerDBContext())
                {
                    var result = db.AlbumTrackerTable.FirstOrDefault(p => p.AlbumID == id);
                    if (result != null)
                    {
                        AlbumTrackerView albumTrackerView = new AlbumTrackerView();
                        albumTrackerView.AlbumID = result.AlbumID;
                        albumTrackerView.AlbumName = result.AlbumName;
                        albumTrackerView.ArtistName = result.ArtistName;
                        albumTrackerView.AlbumDescription = result.AlbumDescription;
                        albumTrackerView.AlbumRating = result.AlbumRating;
                        albumTrackerView.AlbumYear = result.AlbumYear;

                        return albumTrackerView;
                    }
                }
            }

            return null;
        }

        // POST api/AlbumTracker
        [HttpPost]
        public void Post([FromBody] AlbumTrackerView albumTracker)
        { 
            if(albumTracker != null)
            {
                using (AlbumTrackerDBContext db = new AlbumTrackerDBContext())
                {
                    AlbumTrackerRepresentation albumTrackerRepresentation = new AlbumTrackerRepresentation();
                    albumTrackerRepresentation.AlbumName = albumTracker.AlbumName;
                    albumTrackerRepresentation.ArtistName = albumTracker.ArtistName;
                    albumTrackerRepresentation.AlbumDescription = albumTracker.AlbumDescription;
                    albumTrackerRepresentation.AlbumRating = albumTracker.AlbumRating;
                    albumTrackerRepresentation.AlbumYear = albumTracker.AlbumYear;

                    db.AlbumTrackerTable.Add(albumTrackerRepresentation);
                    db.SaveChanges();

                }
            }
        }

        // PUT api/AlbumTracker/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AlbumTrackerView albumTracker)
        {
            using (AlbumTrackerDBContext db = new AlbumTrackerDBContext())
            {
                var result = db.AlbumTrackerTable.FirstOrDefault(p => p.AlbumID == id);
                if (result != null)
                {
                    result.AlbumName = albumTracker.AlbumName;
                    result.ArtistName = albumTracker.ArtistName;
                    result.AlbumDescription = albumTracker.AlbumDescription;
                    result.AlbumRating = albumTracker.AlbumRating;
                    result.AlbumYear = albumTracker.AlbumYear;

                    db.SaveChanges();

                }
            }
        }

        // DELETE api/AlbumTracker/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 0)
            {
                using (AlbumTrackerDBContext db = new AlbumTrackerDBContext())
                {
                    var result = db.AlbumTrackerTable.FirstOrDefault(p => p.AlbumID == id);
                    if (result != null)
                    {
                        db.AlbumTrackerTable.Remove(result);
                        db.SaveChanges();
                    }
                }

            }
        }
    }
}
