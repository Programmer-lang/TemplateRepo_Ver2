using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.SchoolDBContextDataModel;
using SchoolTemplate.Common;
using DataModel;
using DevExpress.Mvvm;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the Schools collection view model.
    /// </summary>
    public partial class SchoolCollectionViewModel : CollectionViewModel<School, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of SchoolCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static SchoolCollectionViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new SchoolCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the SchoolCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SchoolCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected SchoolCollectionViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Schools, null, null, null, false, UnitOfWorkPolicy.Shared) {
        }


        public override void Edit(School projectionEntity)
        {
            var service = this.GetService<IDocumentManagerService>();
            service.ShowExistingEntityDocument<School, decimal>(this, projectionEntity.SchoolID);


        }
    }
}