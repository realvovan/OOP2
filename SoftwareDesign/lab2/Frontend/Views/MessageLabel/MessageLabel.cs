using System.ComponentModel;

namespace SoftwareDesign.lab2.Views; 
public partial class MessageLabel : UserControl {
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Guid MessageId { get; set; }
	public MessageLabel() {
		InitializeComponent();
	}
}
