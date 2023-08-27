using Microsoft.AspNetCore.Mvc;
using VanyaTeach.Course.Data.Models;
using VanyaTeach.Course.Data.Repositories.Lessons;

namespace VanyaTeach.Course.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController(ILessonRepository lessonRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Lesson>> GetAllLessons() =>
        Ok(lessonRepository.GetAllLessons());
    
    [HttpGet("{id:guid}")]
    public ActionResult<Lesson> GetLessonById(Guid id)
    {
        var lesson = lessonRepository.GetLessonById(id);

        return Ok(lesson);
    }

    [HttpPost]
    public ActionResult<Lesson> AddLesson(Lesson lesson)
    {
        lessonRepository.AddLesson(lesson);
        return CreatedAtAction(nameof(GetLessonById), new { id = lesson.Id }, lesson);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateLesson(Guid id, Lesson lesson)
    {
        if (id != lesson.Id) return BadRequest();

        lessonRepository.UpdateLesson(lesson);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteLesson(Guid id)
    {
        lessonRepository.DeleteLesson(id);
        return NoContent();
    }

    [HttpPost("{lessonId:guid}/homework-description")]
    public IActionResult AddHomeworkDescription(Guid lessonId, HomeworkDescription homeworkDescription)
    {
        lessonRepository.AddHomeworkDescriptionToLesson(lessonId, homeworkDescription);
        return Created($"api/lessons/{lessonId}/homework-description", homeworkDescription);
    }

    [HttpPut("{lessonId:guid}/homework-description")]
    public IActionResult UpdateHomeworkDescription(Guid lessonId, HomeworkDescription updatedHomeworkDescription)
    {
        lessonRepository.UpdateHomeworkDescriptionInLesson(lessonId, updatedHomeworkDescription);
        return NoContent();
    }

    [HttpDelete("{lessonId:guid}/homework-description")]
    public IActionResult DeleteHomeworkDescription(Guid lessonId)
    {
        lessonRepository.DeleteHomeworkDescriptionFromLesson(lessonId);
        return NoContent();
    }

    [HttpPost("{lessonId:guid}/homework-submissions")]
    public IActionResult UploadHomeworkSubmission(Guid lessonId, HomeworkSubmission homeworkSubmission)
    {
        lessonRepository.UploadHomeworkSubmissionToLesson(lessonId, homeworkSubmission);
        return Created($"api/lessons/{lessonId}/homework-submissions/{homeworkSubmission.Id}", homeworkSubmission);
    }

    [HttpPut("{lessonId:guid}/homework-submissions/{submissionId}")]
    public IActionResult UpdateHomeworkSubmission(Guid lessonId, Guid submissionId, HomeworkSubmission updatedHomeworkSubmission)
    {
        if (submissionId != updatedHomeworkSubmission.Id) return BadRequest();

        lessonRepository.UpdateHomeworkSubmissionInLesson(lessonId, updatedHomeworkSubmission);
        return NoContent();
    }

    [HttpDelete("{lessonId:guid}/homework-submissions/{submissionId}")]
    public IActionResult DeleteHomeworkSubmission(Guid lessonId, Guid submissionId)
    {
        lessonRepository.DeleteHomeworkSubmissionFromLesson(lessonId, submissionId);
        return NoContent();
    }
}
