using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public Task<IEnumerable<TaskItem>> GetAllAsync()
        => Task.FromResult(_tasks.AsEnumerable());

    public Task<TaskItem?> GetByIdAsync(int id)
        => Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));

    public Task AddAsync(TaskItem task)
    {
        task.Id = _tasks.Count + 1;
        _tasks.Add(task);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TaskItem task)
    {
        var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);

        if (existing != null)
        {
            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.IsCompleted = task.IsCompleted;
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task != null)
            _tasks.Remove(task);

        return Task.CompletedTask;
    }
}