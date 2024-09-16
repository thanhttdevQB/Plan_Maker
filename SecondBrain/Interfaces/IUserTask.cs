using SecondBrain.DTOs.Task;

namespace SecondBrain.Interfaces
{
    public interface IUserTask
    {
        public Task AddTask(UserTaskCreateDTO Model);
        public Task UpdateTask(UserTaskCreateDTO Model);
        public Task DeleteTask(int TaskId);
        public Task<List<UserTaskReadUpdateDTO>> GetAllTaskByUserId(Guid UserId);
    }
}
