using System;
using System.Collections.Generic;
using System.Text;
using Task_1;
using Task_1.Controllers;

namespace Model.Registration
{
    public class ModelProcessor : IModelProcessor
    {
        private readonly IModelRepository modelRepository;
        public ModelProcessor(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }

        public bool ValidateModelDetail(ModelData modelDetail)
        {
            if (modelDetail.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Model Id Cannot be less than zero");
            }
            if (modelDetail.Title == null || modelDetail.Title == "")
            {
                throw new ArgumentException("Title cannot be Null");
            }

            if (modelDetail.Description == null || modelDetail.Description == "")
            {
                throw new ArgumentException("Description cannot be Null");
            }

            if (modelDetail.IsComplete == null)
            {
                throw new ArgumentException("Iscomplete either true or false");
            }


            return true;
        }

        public bool ValidateModelDetailByID(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Model ID cannot be less than 0");
            }
            return true;

        }



        public bool AddModelDetails(ModelData modelDetail)
        {
            if (modelDetail.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Model Id Cannot be less than zero");
            }
            if (modelDetail.Title == null || modelDetail.Title == "")
            {
                throw new ArgumentException("Title cannot be Null");
            }

            if (modelDetail.Description == null || modelDetail.Description == "")
            {
                throw new ArgumentException("Description cannot be Null");
            }

            if (modelDetail.IsComplete == null)
            {
                throw new ArgumentException("Iscomplete either true or false");
            }


            modelRepository.AddModelData(new Task_1.ModelData
            {
                Id = modelDetail.Id,
                Title = modelDetail.Title,
                Description = modelDetail.Description,
                IsComplete = modelDetail.IsComplete
            });

            return true;
        }

        public bool ModifyModelDetails(ModelData modelDetail)
        {
            if (modelDetail.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Model Id Cannot be less than zero");
            }
            if (modelDetail.Title == null || modelDetail.Title == "")
            {
                throw new ArgumentException("Title cannot be Null");
            }

            if (modelDetail.Description == null || modelDetail.Description == "")
            {
                throw new ArgumentException("Description cannot be Null");
            }

            if (modelDetail.IsComplete == null)
            {
                throw new ArgumentException("Iscomplete either true or false");
            }


            modelRepository.ModifyModelData(new Task_1.ModelData
            {
                Id = modelDetail.Id,
                Title = modelDetail.Title,
                Description = modelDetail.Description,
                IsComplete = modelDetail.IsComplete
            });

            return true;
        }

        public bool ValidateForModelDeleteID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Model ID cannot be less than 0");
            }
            return modelRepository.DeleteModelData(id);

        }
    }
}

