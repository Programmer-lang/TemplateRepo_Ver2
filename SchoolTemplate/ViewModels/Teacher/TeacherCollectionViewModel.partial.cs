using DataModel;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
using SchoolTemplate.SchoolDBContextDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SchoolTemplate.ViewModels
{
   
    public partial class TeacherCollectionViewModel
    {
        public List<Teacher> ChangedTeachers = new List<Teacher>();
        public void CourseUpdated(Teacher teacher)
        {
            if (!ChangedTeachers.Contains(teacher))
            {
                teacher.SchoolID = ((SchoolViewModel)ParentViewModel).Entity.SchoolID;
                ChangedTeachers.Add(teacher);
            }
        }

        public bool CanSaveAll() => true;
        public void SaveAll()
        {
            this.Repository.UnitOfWork.SaveChanges();

            foreach (var teacher in ChangedTeachers)
                   Save(teacher);

            ChangedTeachers.Clear();
            
          //  UnitOfWorkSource.GetUnitOfWorkFactory().CreateUnitOfWork().SaveChanges();

        }

        //public override void Save()
        //{
        //    //foreach (var course in ChangedTeachers)
        //    //    DepartmentCoursesDetails.Save(course);
        //    ChangedTeachers.Clear();
        //    base.Save();
        //}
        //public override bool CanSave()
        //{
        //    return ChangedTeachers.Count > 0 || base.CanSave();
        //}
    }
}
namespace SchoolTemplate.ViewModels
{
    /// <summary>
    /// Represents the single Department object view model.
    /// </summary>
    public class Converter : MarkupExtension, IEventArgsConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object sender, object args)
        {
            return ((RowEventArgs)args).Row;
        }
    }
}