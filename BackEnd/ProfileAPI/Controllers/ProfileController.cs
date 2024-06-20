using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProfileAPI;
using DatabaseLibrary;

namespace APIProfil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private static List<Profile> _profileList = new List<Profile>();

        // GET: api/<ProfileController>
        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            return _profileList;
        }

        // POST api/<ProfileController>
        [HttpPost]
        public IActionResult Post([FromBody] Profile profile)
        {
            _profileList.Add(profile);

            using (var db = new Database())
            {
                db.Connect();
                string query = $"INSERT INTO pembeli (nama, password, noTelp, alamat) VALUES ('{profile.Nama}', '{profile.password}', '{profile.NoTelp}', '{profile.Alamat}')";
                db.Query(query);
                db.Disconnect();
            }

            return CreatedAtAction(nameof(Get), new { nama = profile.Nama }, profile);
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{nama}")]
        public IActionResult Put(string nama, [FromBody] Profile updatedProfile)
        {
            var existingProfile = _profileList.Find(p => p.Nama == nama);
            if (existingProfile == null)
            {
                return NotFound();
            }

            // Validate required fields
            if (string.IsNullOrEmpty(updatedProfile.Nama) || string.IsNullOrEmpty(updatedProfile.password) || string.IsNullOrEmpty(updatedProfile.Alamat) || string.IsNullOrEmpty(updatedProfile.NoTelp))
            {
                return BadRequest(new { message = "Nama, Alamat, and NoHP are required." });
            }

            existingProfile.Nama = updatedProfile.Nama;
            existingProfile.password = updatedProfile.password;
            existingProfile.NoTelp = updatedProfile.NoTelp;
            existingProfile.Alamat = updatedProfile.Alamat;

            using (var db = new Database())
            {
                db.Connect();
                string query = $"UPDATE pembeli SET nama='{updatedProfile.Nama}', password='{updatedProfile.password}', noTelp='{updatedProfile.NoTelp}', alamat='{updatedProfile.Alamat}' WHERE nama='{nama}'";
                db.Query(query);
                db.Disconnect();
            }

            return NoContent();
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{nama}")]
        public IActionResult Delete(string nama)
        {
            var profileToRemove = _profileList.Find(p => p.Nama == nama);
            if (profileToRemove == null)
            {
                return NotFound();
            }

            _profileList.Remove(profileToRemove);

            using (var db = new Database())
            {
                db.Connect();
                string query = $"DELETE FROM pembeli WHERE nama='{nama}'";
                db.Query(query);
                db.Disconnect();
            }

            return NoContent();
        }

    }
}
