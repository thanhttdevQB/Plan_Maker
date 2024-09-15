using SecondBrain.DTOs.Task;
using SecondBrain.Models;
using static SecondBrain.Responses.ServiceResponses;

namespace SecondBrain.Interfaces
{
    public interface IUserTask
    {
        public Task<GeneralResponse> AddTask(UserTaskCreateDTO Model);
        public Task<GeneralResponse> UpdateTask(UserTaskCreateDTO Model);
        public Task<GeneralResponse> DeleteTask(int TaskId);
        public Task<List<UserTaskReadUpdateDTO>> GetAllTaskByUserId(Guid UserId);
    }
}
