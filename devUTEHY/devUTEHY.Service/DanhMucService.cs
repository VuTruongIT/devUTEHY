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
    public interface IDanhMucService
    {
        //1
        IEnumerable<DanhMuc> GetAll();
        IEnumerable<DanhMuc> Search(string keyword, int page, int pageSize, string sort, out int totalRow);
        IEnumerable<DanhMuc> GetAll(string keyword);

        //2
        DanhMuc Add(DanhMuc DanhMuc);

        //3
        DanhMuc Delete(int id);

        //4
        void DeleteMulti(Expression<Func<DanhMuc, bool>> where);

        DanhMuc GetById(int id);

        //5
        void Update(DanhMuc DanhMuc);


        void Save();

    }
    public class DanhMucService : IDanhMucService
    {
        private IDanhMucRepository _danhMucRepository;
        private ITagRepository _tagRepository;
        private IDanhMucTagsRepository _danhMucTagsRepository;

        private IUnitOfWork _unitOfWork;

        public DanhMucService(IDanhMucRepository danhMucRepository, IDanhMucTagsRepository danhMucTagsRepository,
            ITagRepository _tagRepository, IUnitOfWork unitOfWork)
        {
            this._danhMucRepository = danhMucRepository;
            this._danhMucTagsRepository = danhMucTagsRepository;
            this._tagRepository = _tagRepository;
            this._unitOfWork = unitOfWork;
        }

        //1
        public IEnumerable<DanhMuc> GetAll()
        {
            return _danhMucRepository.GetAll();
        }

        public IEnumerable<DanhMuc> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _danhMucRepository.GetMulti(x => x.TrangThai && x.Ten.Contains(keyword));

            switch (sort)
            {
                default:
                    query = query.OrderByDescending(x => x.NgayTao);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<DanhMuc> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _danhMucRepository.GetMulti(x => x.Ten.Contains(keyword) || x.MoTa.Contains(keyword));
            else
                return _danhMucRepository.GetAll();
        }

        //2
        public DanhMuc Add(DanhMuc danhMuc)
        {
            var DanhMuc = _danhMucRepository.Add(danhMuc);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(DanhMuc.Tags))
            {
                string[] tags = DanhMuc.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Ten = tags[i];
                        tag.Type = CommonConstants.DanhMucTags;
                        _tagRepository.Add(tag);
                    }

                    DanhMucTags danhMucTags = new DanhMucTags();
                    danhMucTags.DanhMucID = DanhMuc.ID;
                    danhMucTags.TagID = tagId;
                    _danhMucTagsRepository.Add(danhMucTags);
                }
            }
            return DanhMuc;
        }

        //3
        public DanhMuc Delete(int id)
        {
            return _danhMucRepository.Delete(id);
        }

        //4
        public void DeleteMulti(Expression<Func<DanhMuc, bool>> where)
        {
            _danhMucRepository.DeleteMulti(where);
        }

        //5
        public void Update(DanhMuc DanhMuc)
        {
            _danhMucRepository.Update(DanhMuc);
            if (!string.IsNullOrEmpty(DanhMuc.Tags))
            {
                string[] tags = DanhMuc.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Ten = tags[i];
                        tag.Type = CommonConstants.DanhMucTags;
                        _tagRepository.Add(tag);
                    }
                    _danhMucTagsRepository.DeleteMulti(x => x.DanhMucID == DanhMuc.ID);
                    DanhMucTags DanhMucTags = new DanhMucTags();
                    DanhMucTags.DanhMucID = DanhMuc.ID;
                    DanhMucTags.TagID = tagId;
                    _danhMucTagsRepository.Add(DanhMucTags);
                }

            }
        }

        public DanhMuc GetById(int id)
        {
            return _danhMucRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
