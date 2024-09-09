using devUTEHY.Data.Infrastructure;
using devUTEHY.Data.Repositories;
using devUTEHY.Model.Models;
using System.Collections.Generic;

namespace devUTEHY.Service
{
    public interface ILoaiCongNgheService
    {
        //1
        IEnumerable<LoaiCongNghe> GetAll();
        IEnumerable<LoaiCongNghe> GetAll(string keyword);

        //2
        LoaiCongNghe Delete(int id);

        //3
        LoaiCongNghe Add(LoaiCongNghe LoaiCongNghe);
        IEnumerable<LoaiCongNghe> GetAllByParentId(int parentId);

        //4
        LoaiCongNghe GetById(int id);
        void Update(LoaiCongNghe LoaiCongNghe);


        void Save();
    }

    public class LoaiCongNgheService : ILoaiCongNgheService
    {
        private ILoaiCongNgheRepository _LoaiCongNgheRepository;
        private IUnitOfWork _unitOfWork;

        public LoaiCongNgheService(ILoaiCongNgheRepository LoaiCongNgheRepository, IUnitOfWork unitOfWork)
        {
            this._LoaiCongNgheRepository = LoaiCongNgheRepository;
            this._unitOfWork = unitOfWork;
        }

        //1
        public IEnumerable<LoaiCongNghe> GetAll()
        {
            return _LoaiCongNgheRepository.GetAll();
        }

        public IEnumerable<LoaiCongNghe> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _LoaiCongNgheRepository.GetMulti(x => x.Ten.Contains(keyword) || x.MoTa.Contains(keyword));
            else
                return _LoaiCongNgheRepository.GetAll();

        }

        //2
        public LoaiCongNghe Delete(int id)
        {
            return _LoaiCongNgheRepository.Delete(id);
        }

        //3
        public LoaiCongNghe Add(LoaiCongNghe LoaiCongNghe)
        {
            return _LoaiCongNgheRepository.Add(LoaiCongNghe);
        }

        public IEnumerable<LoaiCongNghe> GetAllByParentId(int parentId)
        {
            return _LoaiCongNgheRepository.GetMulti(x => x.TrangThai && x.ParentID == parentId);
        }

        //4
        public LoaiCongNghe GetById(int id)
        {
            return _LoaiCongNgheRepository.GetSingleById(id);
        }
        public void Update(LoaiCongNghe LoaiCongNghe)
        {
            _LoaiCongNgheRepository.Update(LoaiCongNghe);
        }



        public void Save()
        {
            _unitOfWork.Commit();
        }

    }
}