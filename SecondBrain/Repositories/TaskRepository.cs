using SecondBrain.Interfaces;
using SecondBrain.Data;
using SecondBrain.Responses;
using SecondBrain.Models;
using SecondBrain.DTOs.Task;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SecondBrain.Repositories
{
    public class TaskRepository : IUserTask
    {
        private readonly SecondBrainDataContext _context;

        public TaskRepository( SecondBrainDataContext context )
        {
            _context = context;
        }

        public async Task<ServiceResponses.GeneralResponse> AddTask(UserTaskCreateDTO TaskCreateDTO)
        {
            try
            {
                await _context.UserTask.AddAsync(new UserTask
                {
                    Name = TaskCreateDTO.Name,
                    Description = TaskCreateDTO.Description,
                    EndTime = TaskCreateDTO.EndTime,
                    StartTime = TaskCreateDTO.StartTime,
                    Status = TaskCreateDTO.Status,
                    TaskDay = TaskCreateDTO.TaskDay,
                    UserProfile = _context.UserProfile.Find(TaskCreateDTO.UserId)
                });
                _context.SaveChanges();
                return new ServiceResponses.GeneralResponse(true, "Task added");
            }
            catch (Exception ex)
            {
                return new ServiceResponses.GeneralResponse(false, ex.Message);
            }
        }

        public async Task<ServiceResponses.GeneralResponse> UpdateTask(UserTaskReadUpdateDTO UpdateUserTask)
        {
            try
            {
                UserTask newUserTask = new UserTask
                {
                    Description = UpdateUserTask.Description,
                    EndTime= UpdateUserTask.EndTime,
                    StartTime= UpdateUserTask.StartTime,
                    Status = UpdateUserTask.Status,
                    TaskDay = UpdateUserTask.TaskDay,
                    Name = UpdateUserTask.Name,
                };
                _context.UserTask.Update(newUserTask);
                _context.SaveChanges();
                return new ServiceResponses.GeneralResponse(true, "Task updated");
            }
            catch (Exception ex)
            {
                return new ServiceResponses.GeneralResponse(false, ex.Message);
            }
        }

        public async Task<ServiceResponses.GeneralResponse> DeleteTask(Guid TaskId)
        {
            try
            {
                UserTask target = await _context.UserTask.FindAsync(TaskId);
                _context.UserTask.Remove(target);
                _context.SaveChanges();
                return new ServiceResponses.GeneralResponse(true, "Task updated");
            }
            catch (Exception ex)
            {
                return new ServiceResponses.GeneralResponse(false, ex.Message);
            }
        }

        public async Task<List<UserTaskReadUpdateDTO>> GetAllTaskByUserId(Guid UserId)
        {
            try
            {
                List<UserTaskReadUpdateDTO> listTask = new List<UserTaskReadUpdateDTO>();
                var rawListTask = _context.UserTask.Include(x => x.UserProfile).Where(x => x.UserProfile.Id == UserId);
                foreach (UserTask task in rawListTask)
                {
                    listTask.Add(new UserTaskReadUpdateDTO
                    {
                        Id = task.Id,
                        Description = task.Description,
                        StartTime = task.StartTime,
                        EndTime = task.EndTime,
                        TaskDay = task.TaskDay,
                        Name = task.Name,
                        Status = task.Status,
                    });
                }
                return listTask;
            } catch
            {
                return new List<UserTaskReadUpdateDTO>();
            }
        }
    }
}
