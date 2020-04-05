using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.SchoolDBContextDataModel;
using SchoolTemplate.Common;
using DataModel;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the single Department object view model.
    /// </summary>
    public partial class DepartmentViewModel : SingleObjectViewModel<Department, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of DepartmentViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static DepartmentViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new DepartmentViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the DepartmentViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DepartmentViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected DepartmentViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Departments, x => x.DepartmentName) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Schools for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<School> LookUpSchools {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (DepartmentViewModel x) => x.LookUpSchools,
                    getRepositoryFunc: x => x.Schools);
            }
        }

    }
}
