using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TesPraktikKPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PegawaiController : ControllerBase
    {
        public static List<Pegawai> ListPegawai = new List<Pegawai>();
        public static readonly string filePath = "ListPegawai.json";

        [HttpGet]
        public IEnumerable<Pegawai> Get()
        {
            ReadData();
            return ListPegawai;
        }

        [HttpGet("{id}")]
        public ActionResult<Pegawai> Get(string id)
        {
            ReadData();
            Pegawai pegawai = ListPegawai.FirstOrDefault(p => p.ID == id);
            if (pegawai == null)
            {
                return NotFound();
            }
            return pegawai;
        }

        [HttpPost]
        public void Post([FromBody] Pegawai value)
        {
            ReadData();
            value.ID = (ListPegawai.Count + 1).ToString();
            ListPegawai.Add(value);
            SaveData();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Pegawai value)
        {
            ReadData();
            Pegawai pgw = ListPegawai.FirstOrDefault(p => p.ID == id);
            if (existingPegawai == null)
            {
                NotFound();
            }
            pgw.Nama = value.Nama;
            SaveData();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            ReadData();
            Pegawai pegawaiToRemove = ListPegawai.FirstOrDefault(p => p.ID == id);
            if (pegawaiToRemove == null)
            {
                return NotFound();
            }
            ListPegawai.Remove(pegawaiToRemove);
            SaveData();
            return NoContent();
        }

        private void ReadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ListPegawai = JsonConvert.DeserializeObject<List<Pegawai>>(json);
            }
        }

        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(ListPegawai);
            File.WriteAllText(filePath, json);
        }
    }
}