using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.SchoolDBContextDataModel;
using SchoolTemplate.Common;
using DataModel;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using SchoolTemplate.Localization;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the Schools collection view model.
    /// </summary>
    public partial class SchoolCollectionViewModel : CollectionViewModel<School, decimal, ISchoolDBContextUnitOfWork> {


        //public ObservableCollection<MenuIDHistory> MenuIDHistory { get;  set; }

        //public bool IsVisible { get; set; } = false;

        //public virtual MenuIDHistory SelectedMenuID { get; set; }

        //public virtual SchoolDBContextModuleDescription ActiveModule { get; protected set; }

        //public virtual SchoolDBContextModuleDescription SelectedModule { get; set; }

        //const string TablesGroup = "Tables";

        //const string ViewsGroup = "Views";
        //public SchoolDBContextModuleDescription[] Modules { get; set; } = new SchoolDBContextModuleDescription[] {

        //      new SchoolDBContextModuleDescription(SchoolDBContextResources.TeacherPlural, "TeacherCollectionView", TablesGroup, null),
        //      new SchoolDBContextModuleDescription(SchoolDBContextResources.StudentPlural, "StudentCollectionView", TablesGroup, null),
        //      new SchoolDBContextModuleDescription(SchoolDBContextResources.DepartmentPlural, "DepartmentCollectionView", TablesGroup, null),
        //      new SchoolDBContextModuleDescription(SchoolDBContextResources.VehiculePlural, "VehiculeCollectionView", TablesGroup, null),



        //};

        //public void OnSelectedModuleChanged()
        //{
        //    var service = this.GetService<IDocumentManagerService>();

        //    var OpenedDoc = service.Documents.Where(x => x.Title.ToString() == SelectedModule.ModuleTitle).FirstOrDefault();

        //    if (OpenedDoc != null)
        //    {
        //        OpenedDoc.Show();
        //        return;
        //    }

        //    switch (SelectedModule.ModuleTitle)
        //    {


        //        case "Teachers":
        //            var doc = service.CreateDocument(SelectedModule.DocumentType, null, this);
        //            doc.Title = "Teachers";
        //            doc.Show();
        //            break;
        //        case "Students":
        //            var docstud = service.CreateDocument(SelectedModule.DocumentType, null, this);
        //            docstud.Title = "Students";
        //            docstud.Show();
        //            break;

        //        case "Departments":
        //            var docDep = service.CreateDocument(SelectedModule.DocumentType, null, this);
        //            docDep.Title = "Departments";
        //            docDep.Show();
        //            break;

        //        case "Vehicules":
        //            var docVeh = service.CreateDocument(SelectedModule.DocumentType, null, this);
        //            docVeh.Title = "Vehicules";
        //            docVeh.Show();
        //            break;
        //    }

        //}

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

        //public void OnInitialized()
        //{

        //    try
        //    {


        //        MenuIDHistory = new ObservableCollection<MenuIDHistory>(UnitOfWorkSource.GetUnitOfWorkFactory().CreateUnitOfWork().GetMenuIDHistoryData("usp_GetData " + "Ali"));

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBoxService.Show(ex.Message);

        //    }
        //}


        //public void EditID()
        //{
        //    ((SchoolDBContextViewModel)ParentViewModel).IsVisible = true;
        //    ((SchoolDBContextViewModel)ParentViewModel).RaisePropertyChanged(x => x.IsVisible);

        //    var service = this.GetService<IDocumentManagerService>();
        //    service.ShowExistingEntityDocument<School, decimal>(this, SelectedMenuID.ID);

        //    SelectedMenuID = null;
        //}

        
        public void EditSchool(School projectionEntity)
        {
            ((SchoolDBContextViewModel)ParentViewModel).IsVisible = true;
            ((SchoolDBContextViewModel)ParentViewModel).RaisePropertyChanged(x => x.IsVisible);

            SchoolDBContextViewModel.ID = projectionEntity.SchoolID;

            var service = this.GetService<IDocumentManagerService>();
            service.ShowExistingEntityDocument<School, decimal>(this, projectionEntity.SchoolID);

            
        }

    }
}