using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.SchoolDBContextDataModel;
using SchoolTemplate.Common;
using DataModel;
using System.Collections.Specialized;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the Teachers collection view model.
    /// </summary>
    public partial class TeacherCollectionViewModel : CollectionViewModel<Teacher, decimal, ISchoolDBContextUnitOfWork> {

        //public virtual int FocusedRowHandle { get; set; } = 0;


        //IGridControlFirstRowFocusService GridControlFirstRowFocusService { get { return this.GetService<IGridControlFirstRowFocusService>(); } }

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

           // Entities.CollectionChanged += OnCollectionChanged;

            FilterExpression = x => x.SchoolID == ((SchoolViewModel)ParentViewModel).Entity.SchoolID;
        }

        public bool CanSaveAll() => true;
        public void SaveAll()
        {
            this.Repository.UnitOfWork.SaveChanges();

        }

        public void OnInitialized()
        {
            //GridControlFirstRowFocusService.FocusFirstRow();
            //FocusedRowHandle = 0;
            //this.RaisePropertyChanged(x => x.FocusedRowHandle);
        }

        public void OnEntitiesChanged()
        {
            foreach (Teacher newItem in Entities)
            {
                //ModifiedItems.Add(newItem);

                ////Add listener for each item on PropertyChanged event
                //newItem.PropertyChanged += this.OnItemPropertyChanged;

                newItem.SchoolID = ((SchoolViewModel)ParentViewModel).Entity.SchoolID;
                newItem.School = ((SchoolViewModel)ParentViewModel).Entity;
            }
        }
        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Teacher newItem in e.NewItems)
                {
                    //ModifiedItems.Add(newItem);

                    ////Add listener for each item on PropertyChanged event
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;

                    newItem.SchoolID = ((SchoolViewModel)ParentViewModel).Entity.SchoolID;
                    newItem.School = ((SchoolViewModel)ParentViewModel).Entity;
                }
            }

            //if (e.OldItems != null)
            //{
            //    foreach (Item oldItem in e.OldItems)
            //    {
            //        ModifiedItems.Add(oldItem);

            //        oldItem.PropertyChanged -= this.OnItemPropertyChanged;
            //    }
            //}
        }
    }
}