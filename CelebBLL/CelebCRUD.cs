using CelebritiesDAL;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CelebBLL
{
    public interface ICelebCRUD
    {
        List<Celebrity> GetAllCelebrities();
        void Create(Celebrity c);
        void Update(Celebrity c);
        void Delete(int id);
    }

    public class CelebCRUD : ICelebCRUD
    {

        public List<Celebrity> GetAllCelebrities()
        {
            var celebrityRepository = new CelebRepo();
            var celebs = celebrityRepository.GetAllCelebrities();
            return celebs;
        }

        public void Create(Celebrity c)
        {
            var celebrityRepository = new CelebRepo();
            celebrityRepository.CreateCeleb(c);
        }


        public void Update(Celebrity c)
        {
            var celebrityRepository = new CelebRepo();
            celebrityRepository.UpdateCeleb(c);
        }

        public void Delete(int id)
        {
            var celebrityRepository = new CelebRepo();
            celebrityRepository.DeleteCeleb(id);
        }
    }
}
