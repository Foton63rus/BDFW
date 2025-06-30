using System;
using System.Collections.Generic;

namespace BDFW
{
    [Serializable]
    public class GODataHolder
    {
        public int Id;

        public Dictionary<string, IGameObjectData> _data = new();

        public void AddData<T>(string dataName, T data) where T : IGameObjectData
            => _data[dataName] = data;

        public void RemoveData<T>(string dataName) where T : IGameObjectData
            => _data.Remove(dataName);

        public T GetData<T>(string dataName) where T : IGameObjectData
            => _data.TryGetValue(dataName, out var data) ? (T)data : throw new KeyNotFoundException($"Попытка обьратиться к objectdata {dataName} в {Id}");

        public bool HasData<T>(string dataName) where T : IGameObjectData
            => _data.TryGetValue(dataName, out var data) && data is T;

        public IGameObjectData this[string name]
        {
            get => _data.TryGetValue(name, out var data) ? data : throw new KeyNotFoundException($"Попытка обьратиться к objectdata {name} в {Id}");
            set => _data[name] = value;
        }

        public string GetDataString() => $"{_data.Count}";

        public GODataHolder(int id)
        {
            Id = id;
        }
    }
}
