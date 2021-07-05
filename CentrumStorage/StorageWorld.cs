using CentrumStorage.DataStructures;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CentrumStorage
{
    public class StorageWorld : ModWorld
    {
        public Dictionary<Guid, StorageNetwork> Networks;
        public Dictionary<Guid, ItemRepository> DriveRepositories;

        public override void Initialize()
        {
            base.Initialize();

            Networks = new Dictionary<Guid, StorageNetwork>();
            DriveRepositories = new Dictionary<Guid, ItemRepository>();
        }

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound() {
                ["Networks"] = SerializeCollectionOfStorageData(Networks),
                ["DriveRepositories"] = SerializeCollectionOfStorageData(DriveRepositories)
            };

            return tag;
        }

        public List<TagCompound> SerializeCollectionOfStorageData<T>(Dictionary<Guid, T> collection) where T: ISaveAndLoadable
        {
            List<TagCompound> tags = new List<TagCompound>();

            foreach (KeyValuePair<Guid, T> kvp in collection)
            {
                SerializeStorageData(kvp);
            }

            return tags;
        }

        public TagCompound SerializeStorageData<T>(KeyValuePair<Guid, T> data) where T : ISaveAndLoadable => new TagCompound() {
                ["Identifier"] = data.Key,
                ["Data"] = data.Value.Save()
            };

        public override void Load(TagCompound tag)
        {
            base.Load(tag);

            DeserializeStorageDataToCollection(tag, "Networks", ref Networks);
            DeserializeStorageDataToCollection(tag, "DriveRepositories", ref DriveRepositories);
        }

        public void DeserializeStorageDataToCollection<T>(TagCompound tag, string key, ref Dictionary<Guid, T> collection) where T : ISaveAndLoadable, new()
        {
            IList<TagCompound> tags = tag.GetList<TagCompound>(key);

            foreach (TagCompound t in tags)
            {
                DeserializeStorageData(t, ref collection);
            }
        }

        public void DeserializeStorageData<T>(TagCompound tag, ref Dictionary<Guid, T> collection) where T : ISaveAndLoadable, new()
        {
            Guid key = tag.Get<Guid>("Identifier");
            TagCompound data = tag.Get<TagCompound>("Data");

            T value = new T();
            value.Load(data);

            collection.Add(key, value);
        }
    }
}
