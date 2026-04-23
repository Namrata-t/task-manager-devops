using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

public class TaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<TaskItem>> GetAll()
        => await _repo.GetAllAsync();

    public async Task<TaskItem?> GetById(int id)
        => await _repo.GetByIdAsync(id);

    public async Task Create(TaskItem task)
        => await _repo.AddAsync(task);

    public async Task Update(TaskItem task)
        => await _repo.UpdateAsync(task);

    public async Task Delete(int id)
        => await _repo.DeleteAsync(id);
}