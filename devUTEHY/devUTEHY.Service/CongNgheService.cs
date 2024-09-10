using devUTEHY.Common;
using devUTEHY.Data.Infrastructure;
using devUTEHY.Data.Repositories;
using devUTEHY.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace devUTEHY.Service
{
    public interface ICongNgheService
    {
        //1
        IEnumerable<CongNghe> GetAll();
        IEnumerable<CongNghe> Search(string keyword, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<CongNghe> GetAll(string keyword);

        //2
        CongNghe Add(CongNghe CongNghe);

        //3
        CongNghe Delete(int id);

        //4
        void DeleteMulti(Expression<Func<CongNghe, bool>> where);

        CongNghe GetById(int id);

        //5
        void Update(CongNghe CongNghe);


        void Save();

    }
    public class CongNgheService : ICongNgheService
    {
        private ICongNgheRepository _congNgheRepository;
        private ITagRepository _tagRepository;
        private ICongNgheTagsRepository _congNgheTagsRepository;

        private IUnitOfWork _unitOfWork;

        public CongNgheService(ICongNgheRepository congNgheRepository, ICongNgheTagsRepository congNgheTagsRepository,
            ITagRepository _tagRepository, IUnitOfWork unitOfWork)
        {
            this._congNgheRepository = congNgheRepository;
            this._congNgheTagsRepository = congNgheTagsRepository;
            this._tagRepository = _tagRepository;
            this._unitOfWork = unitOfWork;
        }

        //1
        public IEnumerable<CongNghe> GetAll()
        {
            return _congNgheRepository.GetAll();
        }

        public IEnumerable<CongNghe> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _congNgheRepository.GetMulti(x => x.TrangThai && x.Ten.Contains(keyword));

            switch (sort)
            {
                default:
                    query = query.OrderByDescending(x => x.NgayTao);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<CongNghe> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _congNgheRepository.GetMulti(x => x.Ten.Contains(keyword) || x.MoTa.Contains(keyword));
            else
                return _congNgheRepository.GetAll();
        }

        //2
        public CongNghe Add(CongNghe CongNghe)
        {
            var congnghe = _congNgheRepository.Add(CongNghe);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(CongNghe.Tags))
            {
                string[] tags = CongNghe.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Ten = tags[i];
                        tag.Type = CommonConstants.CongNgheTags;
                        _tagRepository.Add(tag);
                    }

                    CongNgheTags congNgheTags = new CongNgheTags();
                    congNgheTags.CongNgheID = CongNghe.ID;
                    congNgheTags.TagID = tagId;
                    _congNgheTagsRepository.Add(congNgheTags);
                }
            }
            return congnghe;
        }

        //3
        public CongNghe Delete(int id)
        {
            return _congNgheRepository.Delete(id);
        }

        //4
        public void DeleteMulti(Expression<Func<CongNghe, bool>> where)
        {
            _congNgheRepository.DeleteMulti(where);
        }

        //5
        public void Update(CongNghe CongNghe)
        {
            _congNgheRepository.Update(CongNghe);
            if (!string.IsNullOrEmpty(CongNghe.Tags))
            {
                string[] tags = CongNghe.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Ten = tags[i];
                        tag.Type = CommonConstants.CongNgheTags;
                        _tagRepository.Add(tag);
                    }
                    _congNgheTagsRepository.DeleteMulti(x => x.CongNgheID == CongNghe.ID);
                    CongNgheTags congNgheTags = new CongNgheTags();
                    congNgheTags.CongNgheID = CongNghe.ID;
                    congNgheTags.TagID = tagId;
                    _congNgheTagsRepository.Add(congNgheTags);
                }

            }
        }

        public CongNghe GetById(int id)
        {
            return _congNgheRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
