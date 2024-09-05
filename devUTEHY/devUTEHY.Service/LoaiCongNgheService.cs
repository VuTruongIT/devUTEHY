using devUTEHY.Data.Infrastructure;
using devUTEHY.Data.Repositories;
using devUTEHY.Model.Models;
using System.Collections.Generic;

namespace devUTEHY.Service
{
    public interface ILoaiCongNgheService
    {
        IEnumerable<LoaiCongNghe> GetAll();

        LoaiCongNghe Add(LoaiCongNghe LoaiCongNghe);

        void Update(LoaiCongNghe LoaiCongNghe);

        LoaiCongNghe Delete(int id);

        IEnumerable<LoaiCongNghe> GetAllByParentId(int parentId);

        LoaiCongNghe GetById(int id);

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
        public IEnumerable<LoaiCongNghe> GetAll()
        {
            return _LoaiCongNgheRepository.GetAll();
        }

        public LoaiCongNghe Add(LoaiCongNghe LoaiCongNghe)
        {
            return _LoaiCongNgheRepository.Add(LoaiCongNghe);
        }

        public LoaiCongNghe Delete(int id)
        {
            return _LoaiCongNgheRepository.Delete(id);
        }

        public IEnumerable<LoaiCongNghe> GetAllByParentId(int parentId)
        {
            return _LoaiCongNgheRepository.GetMulti(x => x.TrangThai && x.ParentID == parentId);
        }

        public LoaiCongNghe GetById(int id)
        {
            return _LoaiCongNgheRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LoaiCongNghe LoaiCongNghe)
        {
            _LoaiCongNgheRepository.Update(LoaiCongNghe);
        }
    }
}