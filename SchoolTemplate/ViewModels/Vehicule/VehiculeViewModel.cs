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
    /// Represents the single Vehicule object view model.
    /// </summary>
    public partial class VehiculeViewModel : SingleObjectViewModel<Vehicule, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of VehiculeViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static VehiculeViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new VehiculeViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the VehiculeViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the VehiculeViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected VehiculeViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Vehicules, x => x.VehiculeName) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Schools for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<School> LookUpSchools {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (VehiculeViewModel x) => x.LookUpSchools,
                    getRepositoryFunc: x => x.Schools);
            }
        }

    }
}
