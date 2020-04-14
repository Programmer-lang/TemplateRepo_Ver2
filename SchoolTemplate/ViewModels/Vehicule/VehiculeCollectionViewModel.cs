using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.SchoolDBContextDataModel;
using SchoolTemplate.Common;
using DataModel;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the Vehicules collection view model.
    /// </summary>
    public partial class VehiculeCollectionViewModel : CollectionViewModel<Vehicule, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of VehiculeCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static VehiculeCollectionViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new VehiculeCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the VehiculeCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the VehiculeCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected VehiculeCollectionViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Vehicules) {

            FilterExpression = x => x.SchoolID == SchoolDBContextViewModel.ID;
        }

        public bool CanSaveAll() => true;
        public void SaveAll()
        {
            this.Repository.UnitOfWork.SaveChanges();

        }
    }
}