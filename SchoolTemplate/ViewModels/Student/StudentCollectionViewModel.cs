using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.SchoolDBContextDataModel;
using SchoolTemplate.Common;
using DataModel;
using DevExpress.Mvvm;
using System.Linq.Expressions;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the Students collection view model.
    /// </summary>
    public partial class StudentCollectionViewModel : CollectionViewModel<Student, decimal, ISchoolDBContextUnitOfWork>
    {

        public override Expression<Func<Student, bool>> FilterExpression { get ; set; } 

        //  public object ParentViewModel { get; set; }

        //public bool AllowSaveReset { get; set; } = true;
        /// <summary>
        /// Creates a new instance of StudentCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static StudentCollectionViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new StudentCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the StudentCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the StudentCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected StudentCollectionViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Students) {


            FilterExpression = x => x.SchoolID == ((SchoolViewModel)ParentViewModel).Entity.SchoolID;
        }

        //,x=> x.Where(y=> y.SchoolID == ParentViewModel.SchoolID)
        public bool CanSaveAll() => true;
        public void SaveAll()
        {
            this.Repository.UnitOfWork.SaveChanges();

        }
    }
}