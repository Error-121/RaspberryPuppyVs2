using RaspberryPuppyVs2.Models;

namespace RaspberryPuppyVs2.Services
{
	public interface IService<T> where T : class
	{
		List<T> GetAll();
		T GetByID(int? id);
		T Add(T item);
		T? Update(int id, T item);
		T? Delete(int id);
	}
}
