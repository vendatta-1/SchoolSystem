using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolSystem.Core.Contract;
using SchoolSystem.Core.Data;

namespace SchoolSystem.Service.Services;

public interface IBaseServices<T, TDto> where T : class, new()
{
    Task<IEnumerable<TDto>> GetAll();
    Task<IEnumerable<TDto>> GetAll(params string[]includes);
    Task<TDto> GetByIdAsync(int id);
    Task<TDto> GetByNameAsync(string name);
    Task<TDto> CreateAsync(TDto dto);
    Task<IEnumerable<TDto>> CreateRangeAsync(IEnumerable<TDto> dtos);
    Task<TDto> UpdateAsync(TDto dto);
    Task<IEnumerable<TDto>> UpdateRangeAsync(IEnumerable<TDto> dtos);
    Task<TDto> DeleteAsync(int id);
    Task<int> DeleteAsync(TDto dto);
    Task<int> DeleteRangeAsync(IEnumerable<TDto> dtos);
    Task<bool> ExistsAsync(int id);
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync();
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<TDto> FirstOrDefaultAsync();
    Task<TDto> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<TDto>> WhereAsync(Expression<Func<T, bool>> predicate);
}


public class BaseServices<T, TDto> : IBaseServices<T, TDto> where T : class, new()
{
    private readonly IBaseRepository<T> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<BaseServices<T, TDto>> _logger;
    public BaseServices(IBaseRepository<T> repository, IMapper mapper,ILogger<BaseServices<T,TDto>> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
//n-tier 
    public async Task<IEnumerable<TDto>> GetAll()
    {

        try
        {
            var data = await _repository.GetAll();
            var dtoData = _mapper.Map<IEnumerable<TDto>>(data);
            return dtoData;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            _logger.LogError(ex.Message);
            throw;
        }
        
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        var data = await _repository.FindById(id);
        return _mapper.Map<TDto>(data);
    }

    public async Task<TDto> GetByNameAsync(string name)
    {
        var data = await _repository.FindByName(name);
        return _mapper.Map<TDto>(data);
    }

    public async Task<TDto> CreateAsync(TDto dto)
    {
        var entity = _mapper.Map<T>(dto);
        var createdEntity = await _repository.Create(entity);
        return _mapper.Map<TDto>(createdEntity);
    }

    public async Task<IEnumerable<TDto>> CreateRangeAsync(IEnumerable<TDto> dtos)
    {
        var entities = _mapper.Map<IEnumerable<T>>(dtos);
        var createdEntities = await _repository.CreateRange(entities);
        return _mapper.Map<IEnumerable<TDto>>(createdEntities);
    }

    public async Task<TDto> UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<T>(dto);
        var updatedEntity = await _repository.Update(entity);
        return _mapper.Map<TDto>(updatedEntity);
    }

    public async Task<IEnumerable<TDto>> UpdateRangeAsync(IEnumerable<TDto> dtos)
    {
        var entities = _mapper.Map<IEnumerable<T>>(dtos);
        var updatedEntities = await _repository.UpdateRange(entities);
        return _mapper.Map<IEnumerable<TDto>>(updatedEntities);
    }

    public async Task<TDto> DeleteAsync(int id)
    {
        var deletedEntity = await _repository.Delete(id);
        return _mapper.Map<TDto>(deletedEntity);
    }

    public async Task<int> DeleteAsync(TDto dto)
    {
        var entity = _mapper.Map<T>(dto);
        return await _repository.Delete(entity);
    }

    public async Task<int> DeleteRangeAsync(IEnumerable<TDto> dtos)
    {
        var entities = _mapper.Map<IEnumerable<T>>(dtos);
        return await _repository.DeleteRange(entities);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.Exists(id);
    }

    public async Task<int> CountAsync()
    {
        return await _repository.Count();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await _repository.Count(predicate);
    }

    public async Task<bool> AnyAsync()
    {
        return await _repository.Any();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _repository.Any(predicate);
    }

    public async Task<TDto> FirstOrDefaultAsync()
    {
        var data = await _repository.FirstOrDefault();
        return _mapper.Map<TDto>(data);
    }

    public async Task<TDto> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        var data = await _repository.FirstOrDefault(predicate);
        return _mapper.Map<TDto>(data);
    }

    public async Task<IEnumerable<TDto>> WhereAsync(Expression<Func<T, bool>> predicate)
    {
        var data = await _repository.Where(predicate);
        return _mapper.Map<IEnumerable<TDto>>(data);
    }

    public async Task<IEnumerable<TDto>> GetAll(params string[] includes)
    {
        var data=await _repository.GetAll(includes);
        return _mapper.Map<IEnumerable<TDto>>(data);
    }
}

