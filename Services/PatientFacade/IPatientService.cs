using System;
using System.Collections.Generic;
using System.Text;
using Exam.CoreData.Models.PagingInfo;
using Exam.CoreData.Models.Patients;

namespace Services.PatientFacade
{
    public interface IPatientService
    {
        BaseSearchResult<PatientModel> SearchPatient(SearchModel search);

        PatientModel GetInfoById(string id);

        bool AddPatient(SavePatientModel model);

        bool UpdatePatient(SavePatientModel model);
      
        bool DeleteOnePatient(int id);

        bool DeleteManyPatient(DeleteManyPatientModel model);

       
    }
}
