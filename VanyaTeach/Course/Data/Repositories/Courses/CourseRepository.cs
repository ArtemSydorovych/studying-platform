using Microsoft.EntityFrameworkCore;
using VanyaTeach.Course.Data.EntityFramework;
using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.Course.Data.Repositories.Courses;

public class CourseRepository(CourseContext context) : ICourseRepository
{
    public IEnumerable<Models.Course> GetAll() =>
        context.Courses
            .ToList();
    
    public Models.Course GetById(Guid id) =>
        context.Courses
            .FirstOrDefault(c => c.Id == id)!;

    public void Add(Models.Course course)
    {
        context.Courses.Add(course);
        context.SaveChanges();
    }

    public void Update(Models.Course course)
    {
        var existingCourse = context.Courses
            .FirstOrDefault(c => c.Id == course.Id);

        if (existingCourse == null) return;

        existingCourse.Name = course.Name;

        context.Entry(existingCourse).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var course = context.Courses.Find(id);
        if (course == null) return;

        context.Courses.Remove(course);
        context.SaveChanges();
    }

    public void AddModule(LessonsModule module)
    {
        context.Modules.Add(module);
        context.SaveChanges();
    }

    public IEnumerable<LessonsModule> GetModules(Guid courseId) =>
        context.Modules
            .Where(m => m.CourseId == courseId)
            .ToList();

    public LessonsModule GetModuleById(Guid moduleId) =>
        context.Modules
            .FirstOrDefault(m => m.Id == moduleId)!;

    public void UpdateModule(LessonsModule module)
    {
        var existingModule = context.Modules
            .FirstOrDefault(m => m.Id == module.Id);

        if (existingModule == null) return;

        existingModule.Title = module.Title;

        context.Entry(existingModule).State = EntityState.Modified;
        context.SaveChanges();
    }
    
    public void DeleteModule(Guid moduleId)
    {
        var module = context.Modules.Find(moduleId);
        context.Modules.Remove(module!);
        context.SaveChanges();
    }
}