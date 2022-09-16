using Domain.UseCase;
using UnityEngine;

namespace Repository
{
    public class PlayerPrefsRepository<T> : IRepository<T>
    {
        private string m_Key;

        public PlayerPrefsRepository(string key)
        {
            m_Key = key;
        }

        public T Read()
        {
            if (PlayerPrefs.HasKey(m_Key))
            {

            }
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(m_Key, "{}"));
        }

        public void Write(T value)
        {
            PlayerPrefs.SetString(m_Key, JsonUtility.ToJson(value));
        }
    }
}