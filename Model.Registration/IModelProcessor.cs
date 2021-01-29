using System;
using Task_1;

namespace Model.Registration
{
    interface IModelProcessor
    {
        bool ValidateModelDetail(ModelData modelDetail);

        bool ValidateModelDetailByID(int id);

        bool AddModelDetails(ModelData modelDetail);

        bool ModifyModelDetails(ModelData modelDetail);

        bool ValidateForModelDeleteID(int id);
    }
}
