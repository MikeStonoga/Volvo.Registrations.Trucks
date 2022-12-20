using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

namespace Volvo.Registrations.Trucks.BusinessModels.Commons.Events;

public class DomainEvent : BusinessModel, IDomainEvent
{
    public string SerializedContent { get; protected set; }
    public string Name { get; protected set; }
    public DateTime CreationTime { get; protected set; }
    public Guid CreatorId { get; protected set; }
    public Guid? PreviousEventId { get; protected set; }

    protected DomainEvent() { }
    protected DomainEvent(string name, object content, Guid id)
        : base(id)
    {
        Name = name;
        SerializedContent = Serialize(content);
        CreationTime = DateTime.UtcNow;
    }

    protected string Serialize(object content)
    {
        var serialized = JsonConvert.SerializeObject(content, settings: GetSerializationSettings());
        return serialized;
    }

    protected static JsonSerializerSettings GetSerializationSettings()
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new PrivateSetterContractResolver(),
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            TypeNameHandling = TypeNameHandling.All
        };

        return settings;
    }

    public static DomainEvent Create(string name, object content, Guid? id = null)
    {
        var validatedId = id ?? Guid.NewGuid();
        return new DomainEvent(name, content, validatedId);
    }

    public void SetPreviousEventId(Guid previousEventId)
        => PreviousEventId = previousEventId;
}

[Serializable]
public class DomainEvent<TContent> : DomainEvent, IDomainEvent<TContent>
{
    public TContent ContentValue => Desserialize(SerializedContent);

    public static TContent Desserialize(string value)
    {
        var desserialized = JsonConvert.DeserializeObject<TContent>(value, settings: GetSerializationSettings());
        return desserialized;
    }

    protected DomainEvent(string name, TContent content, Guid id)
        : base(name, content, id)
    {
        SerializedContent = Serialize(content);
    }

    public static DomainEvent<TContent> Create(string name, TContent content, Guid? id = null)
    {
        var validatedId = id ?? Guid.NewGuid();
        return new DomainEvent<TContent>(name, content, validatedId);
    }
}