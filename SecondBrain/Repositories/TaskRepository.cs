using SecondBrain.Interfaces;
using SecondBrain.Data;
using SecondBrain.Models;
using SecondBrain.DTOs.Task;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SecondBrain.Repositories
{
    public class TaskRepository : IUserTask
    {
        private readonly SecondBrainDataContext _context;

        public TaskRepository(SecondBrainDataContext context)
        {
            _context = context;
        }

        public async Task AddTask(UserTaskCreateDTO TaskCreateDTO)
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
                    UserProfile = _context.UserProfile.Find(TaskCreateDTO.UserId),
                });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task UpdateTask(UserTaskCreateDTO UpdateUserTask)
        {
            try
            {
                UserTask newUserTask = _context.UserTask.Include(x => x.UserProfile).Where(x => x.TaskDay == UpdateUserTask.TaskDay && x.UserProfile.Id == UpdateUserTask.UserId && x.StartTime == UpdateUserTask.StartTime).FirstOrDefault();
                newUserTask.Description = UpdateUserTask.Description;
                newUserTask.EndTime = UpdateUserTask.EndTime;
                newUserTask.StartTime = UpdateUserTask.StartTime;
                newUserTask.Status = UpdateUserTask.Status;
                newUserTask.TaskDay = UpdateUserTask.TaskDay;
                newUserTask.Name = UpdateUserTask.Name;
                _context.UserTask.Update(newUserTask);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                await AddTask(UpdateUserTask);
            }
        }

        public async Task DeleteTask(int TaskId)
        {
            try
            {
                UserTask target = _context.UserTask.Find(TaskId);
                _context.UserTask.Remove(target);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
