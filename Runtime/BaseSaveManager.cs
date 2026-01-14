using UnityEngine;

namespace DBD.SaveGame
{
    public abstract class BaseSaveManager<INSTANCE, DATA> : MonoBehaviour
        where INSTANCE : MonoBehaviour where DATA : BaseDataSave, new()
    {
        public static INSTANCE Instance { get; private set; }

        public DATA DataSave;

        private bool isLoaded;
        private bool isDirty;
        private float timer;

        private const float saveInterval = 2f;

        /// <summary>
        /// Migrate data from fromVersion -> fromVersion + 1
        /// </summary>
        protected abstract void Migrate(int fromVersion);

        protected abstract int Version();

#if UNITY_EDITOR
        protected virtual void Reset()
        {
            ClearData();
        }
#endif


        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<INSTANCE>();

                Transform root = transform.root;
                if (root != transform)
                {
                    DontDestroyOnLoad(root);
                }
                else
                {
                    DontDestroyOnLoad(gameObject);
                }

                LoadData();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnEnable()
        {
            SaveGame.OnValueChanged += OnValueChanged;
        }

        protected virtual void OnDisable()
        {
            SaveGame.OnValueChanged -= OnValueChanged;
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            if (!isDirty) return;

            timer += Time.deltaTime;
            if (timer >= saveInterval) SaveData();
        }

        protected virtual void FixedUpdate()
        {
        }

        protected virtual void OnApplicationPause(bool pause)
        {
            if (pause && isLoaded)
            {
                SaveData();
            }
        }

        protected virtual void OnValueChanged()
        {
            if (!isLoaded) return;
            isDirty = true;
        }

        protected virtual void LoadData()
        {
            string json = SaveGame.LoadData();
#if UNITY_EDITOR
            Debug.LogWarning($"SaveGame - LoadData");
#endif
            if (string.IsNullOrEmpty(json))
            {
                DataSave = new DATA
                {
                    Version = new SaveValue<int>(Version())
                };
                SaveData();
                isLoaded = true;
                return;
            }

            DataSave = JsonUtility.FromJson<DATA>(json);

#if UNITY_EDITOR
            if (DataSave.Version.Value > Version())
            {
                Debug.LogWarning("SaveGame - Save version newer than app version (ignored)");
            }
#endif

            if (DataSave.Version.Value < Version())
            {
                MigrateData(DataSave.Version.Value, Version());
            }

            isLoaded = true;
        }

        protected virtual void MigrateData(int fromVersion, int toVersion)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"SaveGame - Migrate v{fromVersion} -> v{toVersion}");
#endif

            for (int v = fromVersion; v < toVersion; v++)
            {
                Migrate(v);
            }

            DataSave.Version.SetSilently(toVersion);
            SaveData();
        }

        public virtual void SaveData()
        {
#if UNITY_EDITOR
            Debug.LogWarning($"SaveGame - Save Data");
#endif
            isDirty = false;
            timer = 0;
            string json = JsonUtility.ToJson(DataSave);
            SaveGame.SaveData(json);
        }

        public virtual void ClearData()
        {
#if UNITY_EDITOR
            Debug.LogWarning($"SaveGame - Clear Data");
#endif
            SaveGame.ClearData();
        }
    }
}