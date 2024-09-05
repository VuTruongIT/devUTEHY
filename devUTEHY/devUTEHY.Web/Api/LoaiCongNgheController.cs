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

namespace devUTEHY.Web.Api
{
    [RoutePrefix("api/loaicongnghe")]
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

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listloaicongnghe = _loaiCongNgheService.GetAll();

                var listloaicongngheVm = Mapper.Map<List<LoaiCongNgheViewModel>>(listloaicongnghe);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listloaicongngheVm);

                return response;
            });
        }
    }
}
