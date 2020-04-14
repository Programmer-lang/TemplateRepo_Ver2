using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.Localization;
using SchoolTemplate.SchoolDBContextDataModel;
using DataModel;
using System.Collections.ObjectModel;

namespace SchoolTemplate.ViewModels
{
    /// <summary>
    /// Represents the root POCO view model for the SchoolDBContext data model.
    /// </summary>
    public partial class SchoolDBContextViewModel : DocumentsViewModel<SchoolDBContextModuleDescription, ISchoolDBContextUnitOfWork>
    {
        public ObservableCollection<MenuIDHistory> MenuIDHistory { get; set; }
        public virtual MenuIDHistory SelectedMenuID { get; set; }

        public static decimal ID { get; set; }


        public bool IsVisible { get; set; } = false;


        const string TablesGroup = "Tables";

        const string ViewsGroup = "Views";

        /// <summary>
        /// Creates a new instance of SchoolDBContextViewModel as a POCO view model.
        /// </summary>
        public static SchoolDBContextViewModel Create()
        {
            return ViewModelSource.Create(() => new SchoolDBContextViewModel());
        }

        static SchoolDBContextViewModel()
        {
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata<SchoolDBContextMetadataProvider>();
        }
        /// <summary>
        /// Initializes a new instance of the SchoolDBContextViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SchoolDBContextViewModel type without the POCO proxy factory.
        /// </summary>
        protected SchoolDBContextViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory())
        {
           // DefaultModule = new SchoolDBContextModuleDescription(SchoolDBContextResources.SchoolPlural, "SchoolCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Schools)));


        }

        protected override SchoolDBContextModuleDescription[] CreateModules()
        {
            return new SchoolDBContextModuleDescription[] {
                    new SchoolDBContextModuleDescription(SchoolDBContextResources.TeacherPlural, "TeacherCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Teachers)),
                    new SchoolDBContextModuleDescription(SchoolDBContextResources.StudentPlural, "StudentCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Students)),
                    new SchoolDBContextModuleDescription(SchoolDBContextResources.DepartmentPlural, "DepartmentCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Departments)),
                    new SchoolDBContextModuleDescription(SchoolDBContextResources.VehiculePlural, "VehiculeCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Vehicules)),
                };
        }
        //public void EditSchool(School projectionEntity)
        //{
        //    IsVisible = true;
        //    this.RaisePropertyChanged(x => x.IsVisible);

        //    var service = this.GetService<IDocumentManagerService>();
        //    service.ShowExistingEntityDocument<School, decimal>(this, projectionEntity.SchoolID);


        //}

        public override void OnLoaded(SchoolDBContextModuleDescription module)
        {
            base.OnLoaded(module);
            this.Show(new SchoolDBContextModuleDescription(SchoolDBContextResources.SchoolPlural, "SchoolCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Schools)));

            MenuIDHistory = new ObservableCollection<MenuIDHistory>(UnitOfWorkSource.GetUnitOfWorkFactory().CreateUnitOfWork().GetMenuIDHistoryData("usp_GetData " + "Ali"));

        }

        public void EditID()
        {
            IsVisible = true;
            this.RaisePropertyChanged(x => x.IsVisible);

            ID = SelectedMenuID.ID;

            var service = this.GetService<IDocumentManagerService>();
            service.ShowExistingEntityDocument<School, decimal>(this, SelectedMenuID.ID);

            SelectedMenuID = null;
        }


        //protected override void OnActiveModuleChanged(SchoolDBContextModuleDescription oldModule)
        //{
        //    base.OnActiveModuleChanged(oldModule); 

        //   if(this.ActiveModule == null && this.DocumentManagerService.Documents.Where(x=> x.Title.ToString() == "Teachers" || x.Title.ToString() == "Students" || x.Title.ToString().StartsWith("School -")).FirstOrDefault() == null)
        //   {

        //   }
        //}

       

    }

    public partial class SchoolDBContextModuleDescription : ModuleDescription<SchoolDBContextModuleDescription>
    {
        public SchoolDBContextModuleDescription(string title, string documentType, string group, Func<SchoolDBContextModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory)
        {
        }
    }
}