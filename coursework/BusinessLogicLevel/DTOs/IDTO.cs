namespace Coursework.BusinessLevel.DTOs;

public interface IDTO {
	Guid? Guid { get; init; }
	DateTime? CreatedAt { get; init; }
	object ToEntity();
}
public interface IDTO<T> : IDTO {
	new T ToEntity();
}