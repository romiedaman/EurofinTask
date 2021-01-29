using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Task_1.Models;

namespace Task_1.Controllers
{

    public class ModelController : ApiController
    {
        private IModelRepository _modelRepository;
        public ModelController()
        {
            _modelRepository = new ModelRepository(new EurofinsTaskEntities());
        }
        public ModelController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }



        [HttpGet]
        public async Task<HttpResponseMessage> GetAllModelData()
        {
            ModelController Model = new ModelController();
            return Request.CreateResponse(HttpStatusCode.OK, await Task.Run(() => Model._modelRepository.GetAllModelData()));
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetModelByID(int id)
        {
            ModelController m = new ModelController();
            var Model = _modelRepository.GetModelByID(id);
            if (Model == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, await Task.Run(() => "Record Not Found"));
            }
            return Request.CreateResponse(HttpStatusCode.OK, await Task.Run(() => Model));
        }


        //Post Method
        [HttpPost]
        public async Task<HttpResponseMessage> AddModelData(ModelData e)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, await Task.Run(() => "Invalid data."));

            _modelRepository.AddModelData(e);

            return Request.CreateResponse(HttpStatusCode.OK, await Task.Run(() => "Record Inserted Successfully"));
        }

        //Post Method
        [HttpPut]
        public async Task<HttpResponseMessage> ModifyModelData(ModelData e)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, await Task.Run(() => "Invalid data."));
            }
            else
            {
                int CountModelData = await checkValidUSer(e.Id);
                if (CountModelData == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, await Task.Run(() => "Invalid Model ID."));
                }
                else
                {
                    _modelRepository.ModifyModelData(e);

                    return Request.CreateResponse(HttpStatusCode.OK, await Task.Run(() => "Record Updated Successfully"));
                }
            }

        }

        //HttpDelete
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteModelData(int id)
        {

            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, await Task.Run(() => "Please Enter Valid Model No"));
            }
            else
            {
                int CountEmployee = await checkValidUSer(id);
                if (CountEmployee == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, await Task.Run(() => "Invalid Model ID."));
                }
                else
                {
                    _modelRepository.DeleteModelData(id);
                    return Request.CreateResponse(HttpStatusCode.OK, await Task.Run(() => "Record Deleted Successfully"));
                }
            }

        }

        public async Task<int> checkValidUSer(int id)
        {
            var Model = _modelRepository.GetModelByID(id);
            if (Model == null)
            {
                return await Task.Run(() => 0);
            }
            else
            {
                return await Task.Run(() => 1); ;
            }
        }
    }
}
