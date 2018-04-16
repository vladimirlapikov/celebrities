using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace CelebritiesDAL
{
    public class CelebRepo
    {
        // change to relative path
        public const string PATH = "C:/Users/Vladimir Gold/source/repos/CelebritiesAPI/CelebritiesAPI/CelebsMockData/celebs.json";

        public List<Celebrity> GetAllCelebrities()
        {
            using (StreamReader streamReader = new StreamReader(PATH))
            {
                string json = streamReader.ReadToEnd();
                List<Celebrity> celebs = JsonConvert.DeserializeObject<List<Celebrity>>(json);
                return celebs;
            } 
        }

        public void CreateCeleb(Celebrity celebrity)
        {
            StreamReader streamReader = new StreamReader(PATH);
            string json = streamReader.ReadToEnd();
            List<Celebrity> celebs = JsonConvert.DeserializeObject<List<Celebrity>>(json);
            
            var highestId = celebs.Max(x => x.ID);
            var newCelebId = highestId + 1;
            var itemToCreate = new Celebrity();
            itemToCreate.ID = newCelebId;
            itemToCreate.Name = celebrity.Name;
            itemToCreate.Age = celebrity.Age;
            itemToCreate.Country = celebrity.Country;
            celebs.Add(itemToCreate);
            streamReader.Close();

            StreamWriter writer = new StreamWriter(PATH, false);
            var celebsOut = JsonConvert.SerializeObject(celebs, Formatting.Indented);
            writer.Write(celebsOut);
            writer.Close();
        }

        // UpdateCeleb
        public void UpdateCeleb(Celebrity celebrity)
        {
            StreamReader streamReader = new StreamReader(PATH);
            string json = streamReader.ReadToEnd();
            List<Celebrity> celebs = JsonConvert.DeserializeObject<List<Celebrity>>(json);
            streamReader.Close();

            StreamWriter writer = new StreamWriter(PATH, false);
            var itemToUpdate = celebs.Single(c => c.ID == celebrity.ID);
            itemToUpdate.Name = celebrity.Name;
            itemToUpdate.Age = celebrity.Age;
            itemToUpdate.Country = celebrity.Country;
            var celebsOut = JsonConvert.SerializeObject(celebs, Formatting.Indented);
            writer.Write(celebsOut);
            writer.Close();
        }


        public void DeleteCeleb(int id)
        {
            StreamReader streamReader = new StreamReader(PATH);
            string json = streamReader.ReadToEnd();
            List<Celebrity> celebs = JsonConvert.DeserializeObject<List<Celebrity>>(json);
            streamReader.Close();
            
            StreamWriter writer = new StreamWriter(PATH, false);
            var itemToRemove = celebs.Single(c => c.ID == id);
            celebs.Remove(itemToRemove);
            var celebsOut = JsonConvert.SerializeObject(celebs, Formatting.Indented); 
            writer.Write(celebsOut);
            writer.Close();
        }
    }
}
