namespace Coursework.BusinessLevel.DTOs;

public interface IDTO {
	Guid? Guid { get; set; }
	object ToEntity();
}
public interface IDTO<T> : IDTO {
	new T ToEntity();
}