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
    [RoutePrefix("api/loaicongnghes")]
    public class LoaiCongNgheController : ApiControllerBase
    {
        #region Initialize
        ILoaiCongNgheService _loaiCongNgheService;
        public LoaiCongNgheController(IErrorService errorService, ILoaiCongNgheService loaiCongNgheService)
        : base(errorService)
        {
            this._loaiCongNgheService = loaiCongNgheService;
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
                var model = _loaiCongNgheService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.NgayTao).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<LoaiCongNghe>, IEnumerable<LoaiCongNgheViewModel>>(query);

                var paginationSet = new PaginationSet<LoaiCongNgheViewModel>()
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
                    var oldLoaiCongNghe = _loaiCongNgheService.Delete(id);
                    _loaiCongNgheService.Save();

                    var responseData = Mapper.Map<LoaiCongNghe, LoaiCongNgheViewModel>(oldLoaiCongNghe);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        //3
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedLoaiCongNghe)
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
                    var listLoaiCongNghe = new JavaScriptSerializer().Deserialize<List<int>>(checkedLoaiCongNghe);
                    foreach (var item in listLoaiCongNghe)
                    {
                        _loaiCongNgheService.Delete(item);
                    }

                    _loaiCongNgheService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listLoaiCongNghe.Count);
                }

                return response;
            });
        }

        //4
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, LoaiCongNgheViewModel loaiCongNgheVM)
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
                    var newLoaiCongNghe = new LoaiCongNghe();
                    newLoaiCongNghe.UpdateLoaiCongNghe(loaiCongNgheVM);
                    newLoaiCongNghe.NgayTao = DateTime.Now;

                    _loaiCongNgheService.Add(newLoaiCongNghe);
                    _loaiCongNgheService.Save();

                    var responseData = Mapper.Map<LoaiCongNghe, LoaiCongNgheViewModel>(newLoaiCongNghe);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _loaiCongNgheService.GetAll();

                var responseData = Mapper.Map<IEnumerable<LoaiCongNghe>, IEnumerable<LoaiCongNgheViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        //5
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _loaiCongNgheService.GetById(id);

                var responseData = Mapper.Map<LoaiCongNghe, LoaiCongNgheViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, LoaiCongNgheViewModel loaiCongNgheVM)
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
                    var dbLoaiCongNghe = _loaiCongNgheService.GetById(loaiCongNgheVM.ID);

                    dbLoaiCongNghe.UpdateLoaiCongNghe(loaiCongNgheVM);
                    dbLoaiCongNghe.NgayCapNhat = DateTime.Now;

                    _loaiCongNgheService.Update(dbLoaiCongNghe);
                    _loaiCongNgheService.Save();

                    var responseData = Mapper.Map<LoaiCongNghe, LoaiCongNgheViewModel>(dbLoaiCongNghe);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}
