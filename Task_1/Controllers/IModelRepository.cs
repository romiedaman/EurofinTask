using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Models;

namespace Task_1.Controllers
{
    public interface IModelRepository : IDisposable
    {
        IEnumerable<ModelData> GetAllModelData();
        ModelData GetModelByID(int id);
        void AddModelData(ModelData model);
        void ModifyModelData(ModelData model);
        bool DeleteModelData(int id);
    }
}