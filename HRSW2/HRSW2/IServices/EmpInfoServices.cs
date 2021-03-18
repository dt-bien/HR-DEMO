using HRSW2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.IServices
{
    public interface IEmpInfoServices
    {
        //Red
        EmpInfo GetAllEmp();
        EmpInfo GetEmp(int id);

        //create
        EmpInfo CreateEmp();
        // Update
        EmpInfo UpdateEmp();
        //Delete
        EmpInfo DeleteEmp();


    }
}
