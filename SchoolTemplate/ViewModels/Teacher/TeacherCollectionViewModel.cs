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
    /// Represents the Teachers collection view model.
    /// </summary>
    public partial class TeacherCollectionViewModel : CollectionViewModel<Teacher, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of TeacherCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TeacherCollectionViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new TeacherCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the TeacherCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the TeacherCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TeacherCollectionViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Teachers) {

            FilterExpression = x => x.SchoolID == ((SchoolViewModel)ParentViewModel).Entity.SchoolID;
        }

        public bool CanSaveAll() => true;
        public void SaveAll()
        {
            this.Repository.UnitOfWork.SaveChanges();

        }
    }
}