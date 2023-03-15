using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class Collection : MonoBehaviour
    {
        [SerializeField] private CollectionObject[] _collectionList;
        public CollectionObject[] CollectionObjects { get => _collectionList; }

        public void Unlock(int id)
        {
            if(id < 0 || id > _collectionList.Length)
                return;

            _collectionList[id].Unlock();
        }
    }
}
