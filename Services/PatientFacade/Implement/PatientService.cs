using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exam.CoreData.Entities;
using Exam.CoreData.Enums;
using Exam.CoreData.Models.PagingInfo;
using Exam.CoreData.Models.Patients;
using Exam.CoreData.Repository.Common;
using Exam.Libraries.Utils;
using Exam.Services;

namespace Services.PatientFacade.Implement
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public BaseSearchResult<PatientModel> SearchPatient(SearchModel search)
        {
            var result = new BaseSearchResult<PatientModel>();
            var list = _patientRepository.FinAllPaging(search, c => !string.IsNullOrEmpty(c.PatientId), a => a.PatientId);

            var test = new PatientModel();
            test.Status = PatientStatus.InTherapy;
            test.StatusDescription = test.Status.ToDescription();

            result.Records = list.Records.CloneToListModels<Patient, PatientModel>();
            result.Records.ForEach(c => c.StatusDescription = c.Status.HasValue ? c.Status.ToDescription() : string.Empty);
            result.PageCount = list.PageCount;
            result.PageIndex = list.PageIndex;
            result.PageSize = list.PageSize;
            result.TotalRecord = list.TotalRecord;
            return result;
        }

        public PatientModel GetInfoById(string id)
        {
            var exist = _patientRepository.FindById(id);
            return (exist != null) ? exist.CloneToModel<Patient, PatientModel>() : null;
        }

        public bool AddPatient(SavePatientModel model)
        {
            if (string.IsNullOrEmpty(model.PatientId)) throw new ServiceException("PatientId field cannot be empty");
            var exist = _patientRepository.FindById(model.PatientId);
            if (exist == null) throw new ServiceException("PatientId already exists");
            return _patientRepository.Insert(new Patient
            {
                PatientId = model.PatientId,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Birthday = model.Birthday,
                Gender = model.Gender,
                Phone = model.Phone,
                Address = model.Address,
                Status = model.Status
            });
        }

        public bool UpdatePatient(SavePatientModel model)
        {
            if (string.IsNullOrEmpty(model.PatientId)) throw new ServiceException("PatientId field cannot be empty");

            var exist = _patientRepository.FindById(model.PatientId);
            if (exist == null) throw new ServiceException("Patient not exist");

            exist.Firstname = model.Firstname;
            exist.Lastname = model.Lastname;
            exist.Birthday = model.Birthday;
            exist.Gender = model.Gender;
            exist.Phone = model.Phone;
            exist.Address = model.Address;
            exist.Status = model.Status;
            return _patientRepository.Update(exist);
        }

        public bool DeleteOnePatient(int id)
        {
            var exist = _patientRepository.FindById(id);
            if (exist == null)
                throw new ServiceException("This patient has id that does not exist");
            return _patientRepository.Delete(exist);
        }

        public bool DeleteManyPatient(DeleteManyPatientModel model)
        {
            var result = false;
            if (model.Ids.Count() == 0)
                throw new ServiceException("Please select at least 1 department");
            using (var context = _patientRepository.GetDBContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in model.Ids)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                result = _patientRepository.Delete(new Patient { PatientId = item });
                                if (!result)
                                {
                                    trans.Rollback();
                                    break;
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                break;
                            }                            
                        }
                        if (result) trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }
            return result;
        }
    }
}
