namespace tpmodul10_103022300107.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
    {
        new Mahasiswa { Nama = "Relingga Aditya", Nim = "103022300107" },
        new Mahasiswa { Nama = "Ariq Hisyam Nabil", Nim = "103022300034" },
          new Mahasiswa { Nama = "Ade Fathia Nuraini", Nim = "103022300134" },
           new Mahasiswa { Nama = "Nur Ahmadi Aditya Nanda", Nim = "103022300149" },
                 new Mahasiswa { Nama = "Muhammad Farras", Nim = "103022300042" },
    };


        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return mahasiswaList;
        }


        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();
            return mahasiswaList[index];
        }


        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { index = mahasiswaList.Count - 1 }, mahasiswa);
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();
            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }

}
