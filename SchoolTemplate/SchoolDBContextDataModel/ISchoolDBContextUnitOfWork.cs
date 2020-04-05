using DataModel;
using DevExpress.Mvvm.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTemplate.SchoolDBContextDataModel {

    /// <summary>
    /// ISchoolDBContextUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface ISchoolDBContextUnitOfWork : IUnitOfWork {
        
        

        /// <summary>
        /// The Course entities repository.
        /// </summary>
		IRepository<Course, decimal> Courses { get; }
        
        /// <summary>
        /// The Student entities repository.
        /// </summary>
		IRepository<Student, decimal> Students { get; }
        
        /// <summary>
        /// The School entities repository.
        /// </summary>
		IRepository<School, decimal> Schools { get; }
        
        /// <summary>
        /// The Department entities repository.
        /// </summary>
		IRepository<Department, decimal> Departments { get; }
        
        /// <summary>
        /// The Teacher entities repository.
        /// </summary>
		IRepository<Teacher, decimal> Teachers { get; }
        
        /// <summary>
        /// The Vehicule entities repository.
        /// </summary>
		IRepository<Vehicule, decimal> Vehicules { get; }

         List<MenuIDHistory> GetMenuIDHistoryData(string p_sQuery);
    }
}
