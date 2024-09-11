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
    [RoutePrefix("api/danhmuc")]
    public class DanhMucController : ApiControllerBase
    {
        #region Initialize
        private IDanhMucService _danhMucService;

        public DanhMucController(IErrorService errorService, IDanhMucService danhMucService)
            : base(errorService)
        {
            this._danhMucService = danhMucService;
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
                var model = _danhMucService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.NgayTao).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<DanhMuc>, IEnumerable<DanhMucViewModel>>(query);

                var paginationSet = new PaginationSet<DanhMucViewModel>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucViewModel DanhMucVM)
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
                    var newProduct = new DanhMuc();
                    newProduct.UpdateDanhMuc(DanhMucVM);
                    newProduct.NgayTao = DateTime.Now;
                    _danhMucService.Add(newProduct);
                    _danhMucService.Save();

                    var responseData = Mapper.Map<DanhMuc, DanhMucViewModel>(newProduct);
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
                    var oldDanhMuc = _danhMucService.Delete(id);
                    _danhMucService.Save();

                    var responseData = Mapper.Map<DanhMuc, DanhMucViewModel>(oldDanhMuc);
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
                var model = _danhMucService.GetById(id);

                var responseData = Mapper.Map<DanhMuc, DanhMucViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        //5
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, DanhMucViewModel DanhMucVM)
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
                    var dbDanhMuc = _danhMucService.GetById(DanhMucVM.ID);

                    dbDanhMuc.UpdateDanhMuc(DanhMucVM);
                    dbDanhMuc.NgayCapNhat = DateTime.Now;

                    _danhMucService.Update(dbDanhMuc);
                    _danhMucService.Save();

                    var responseData = Mapper.Map<DanhMuc, DanhMucViewModel>(dbDanhMuc);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        //6
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedDanhMucs)
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
                    var listDanhMuc = new JavaScriptSerializer().Deserialize<List<int>>(checkedDanhMucs);
                    foreach (var item in listDanhMuc)
                    {
                        _danhMucService.Delete(item);
                    }

                    _danhMucService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listDanhMuc.Count);
                }

                return response;
            });
        }
    }
}