using RepoDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CelebritiesBLL
{
    public interface ICelebrityCRUD
    {
        List<Celebrity> GetAllCelebrities();
        void Create(Celebrity p);
        void Update(int id, Celebrity p);
        void Delete(int id);
    }

    public class CelebrityCRUD : ICelebrityCRUD
    {

        public List<Celebrity> GetAllCelebrities()
        {
            var celebrityRepository = new CelebrityRepository();
            var celebs = celebrityRepository.GetAllCelebrities();
            return celebs;
        }

        public void Create(Celebrity c)
        {
            var celebrityRepository = new CelebrityRepository();
            celebrityRepository.CreateCeleb(c);
        }


        public void Update(int id, Celebrity c)
        {
            var celebrityRepository = new CelebrityRepository();
            celebrityRepository.UpdateCeleb(id,c);
        }

        public void Delete(int id)
        {
            var celebrityRepository = new CelebrityRepository();
            celebrityRepository.DeleteCeleb(id);
        }
    }
}
