using System.ComponentModel;

namespace Coursework.PresentationLevel;

/// <summary>
/// A label that stores the Guid of the object it represents
/// </summary>
class GuidLabel(Guid guid) : Label() {
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Guid Guid { get; set; } = guid;
}