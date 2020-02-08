namespace Sauce
{
    public abstract class ManagerBase
    {
        public short CurrentLevel { get; private set; }

        public virtual void Awake()
        { }

        public virtual void Start()
        { }

        public virtual void Update()
        { }

        public virtual void FixedUpdate()
        { }

        /// <summary>
        /// Either pausing or exiting app
        /// </summary>
        public virtual void OnApplicationStop()
        { }

        internal void AddLevel() => CurrentLevel++;
    }
}