using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using devUTEHY.Infrastructure.Core;
using devUTEHY.Model.Models;
using devUTEHY.Service;
using devUTEHY.Web.Models;
using devUTEHY.Web.Infrastructure.Extensions;

namespace devUTEHY.Web.Api
{
    [RoutePrefix("api/congnghe")]
    public class CongNgheController : ApiControllerBase
    {
        #region Initialize
        private ICongNgheService _congNgheService;

        public CongNgheController(IErrorService errorService, ICongNgheService congNgheService)
            : base(errorService)
        {
            this._congNgheService = congNgheService;
        }

        #endregion

        //1
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _congNgheService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.NgayTao).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<CongNghe>, IEnumerable<CongNgheViewModel>>(query);

                var paginationSet = new PaginationSet<CongNgheViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        //2
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CongNgheViewModel congNgheVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProduct = new CongNghe();
                    newProduct.UpdateCongNghe(congNgheVM);
                    newProduct.NgayTao = DateTime.Now;
                    _congNgheService.Add(newProduct);
                    _congNgheService.Save();

                    var responseData = Mapper.Map<CongNghe, CongNgheViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        //3
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldCongNghe = _congNgheService.Delete(id);
                    _congNgheService.Save();

                    var responseData = Mapper.Map<CongNghe, CongNgheViewModel>(oldCongNghe);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        //4
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _congNgheService.GetById(id);

                var responseData = Mapper.Map<CongNghe, CongNgheViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        //5
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CongNgheViewModel congNgheVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbCongNghe = _congNgheService.GetById(congNgheVM.ID);

                    dbCongNghe.UpdateCongNghe(congNgheVM);
                    dbCongNghe.NgayCapNhat = DateTime.Now;

                    _congNgheService.Update(dbCongNghe);
                    _congNgheService.Save();

                    var responseData = Mapper.Map<CongNghe, CongNgheViewModel>(dbCongNghe);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        //6
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedCongNghes)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listCongNghe = new JavaScriptSerializer().Deserialize<List<int>>(checkedCongNghes);
                    foreach (var item in listCongNghe)
                    {
                        _congNgheService.Delete(item);
                    }

                    _congNgheService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listCongNghe.Count);
                }

                return response;
            });
        }

        //7
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _congNgheService.GetAll();

                var responseData = Mapper.Map<IEnumerable<CongNghe>, IEnumerable<CongNgheViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}