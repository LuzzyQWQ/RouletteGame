using System.Collections.Generic;

namespace Argali.Module.DataBase.IO
{
	/// <summary>
	/// 基于ES3的数据服务抽象类
	/// </summary>

	public abstract class ServiceBase
    {
        protected readonly ES3File _dataFile;
        private readonly Dictionary<string, object> _cache;

        protected ServiceBase()
        {
            string path = $"bb2_es3/{GetType().Name}";
            var es3Setting = new ES3Settings{ path = path };
            _dataFile = new ES3File(es3Setting, true);
            _cache = new Dictionary<string, object>();
        }

        public virtual void Sync()
        {
            _dataFile.Sync();
        }

        public virtual void Clear()
        {
            if (_dataFile != null)
            {
                _dataFile.Clear();
                _cache.Clear();
                Sync();
            }
        }

        protected T LoadWithCache<T>(string key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache.Add(key, _dataFile.Load(key));
            }

            return (T)_cache[key];
        }

        protected T LoadWithCache<T>(string key, T defaultValue)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache.Add(key, _dataFile.Load(key, defaultValue));
            }

            return (T)_cache[key];
        }

        protected void SaveWithCache<T>(string key, T value)
        {
            _cache[key] = value;
            _dataFile.Save(key, value);
        }
    }
}
