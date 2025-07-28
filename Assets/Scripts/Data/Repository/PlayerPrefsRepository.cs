using Domain.UseCase;
using UnityEngine;

namespace Repository
{
    public class PlayerPrefsRepository<T> : IRepository<T>
    {
        private readonly string _key;

        public PlayerPrefsRepository(string key)
        {
            _key = key;
        }

        public T Read()
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(_key, "{}"));
        }

        public void Write(T value)
        {
            PlayerPrefs.SetString(_key, JsonUtility.ToJson(value));
            PlayerPrefs.Save();
        }
    }
}