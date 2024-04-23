using System;
using UI;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Object = UnityEngine.Object;

namespace Quiz
{
    [Serializable]
    public class AnswerButtonFactory : IInitializable
    {
        [SerializeField] private Transform root;
        [SerializeField] private AnswerButton prefab;
        [SerializeField][Min(0)] private int defaultCapacity;
        
        private ObjectPool<AnswerButton> _pool;
        
        private bool _isInitialized;
        
        public AnswerButtonFactory(AnswerButton prefab, Transform root = null, int defaultCapacity = 4)
        {
            this.root = root;
            this.prefab = prefab;
            this.defaultCapacity = defaultCapacity;
        }
        
        public void Initialize()
        {
            if (_isInitialized) return;
            _pool = new ObjectPool<AnswerButton>(CreateNewButton, OnButtonGet, OnButtonRelease, OnButtonDestroy, true, defaultCapacity);
            _isInitialized = true;
        }
        
        public AnswerButton CreateButton()
        {
            if (!_isInitialized) throw new InvalidOperationException("Factory is not initialized");
            var button = _pool.Get();
            button.transform.SetParent(root);
            return button;
        }

        private void OnButtonGet(AnswerButton obj)
        {
            obj.gameObject.SetActive(true);
        }

        private void OnButtonRelease(AnswerButton obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnButtonDestroy(AnswerButton obj)
        {
            Object.Destroy(obj.gameObject);
        }

        private AnswerButton CreateNewButton()
        {
            var button = Object.Instantiate(prefab, root);
            button.Released += () => _pool.Release(button);
            return button;
        }
        
        
    }
}