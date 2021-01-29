using System;
using System.Collections.Generic;
using System.Linq;
using Task_1.Models;
using System.Data;
using System.Data.Entity;

namespace Task_1.Controllers
{
    public class ModelRepository : IModelRepository
    {
        private readonly EurofinsTaskEntities _context;

        public ModelRepository(EurofinsTaskEntities context)
        {
            _context = context;
        }

        //Get All Employee
        public IEnumerable<ModelData> GetAllModelData()
        {
            return _context.ModelDatas.ToList();
        }

        //Get All Employee By ID
        public ModelData GetModelByID(int id)
        {
            return _context.ModelDatas.FirstOrDefault<ModelData>(e => e.Id == id);
        }

        // Insert New Record
        public void AddModelData(ModelData e)
        {
            _context.ModelDatas.Add(e);
            _context.SaveChanges();
        }

        // Update Record
        public void ModifyModelData(ModelData e)
        {

            var id = _context.ModelDatas.Find(e.Id);
            _context.Entry(id).CurrentValues.SetValues(e);
            _context.Entry(id).State = EntityState.Modified;
            _context.SaveChanges();
        }


        //Delete Record
        public bool DeleteModelData(int id)
        {
            ModelData model = _context.ModelDatas.Find(id);
            _context.ModelDatas.Remove(model);
            _context.SaveChanges();
            return true;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }


    }
}