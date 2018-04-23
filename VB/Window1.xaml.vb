Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.Globalization

Namespace DemoNavBar

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class LerpConverter
		Inherits MarkupExtension
		Implements IValueConverter
		Private privateOffset As Double
		Public Property Offset() As Double
			Get
				Return privateOffset
			End Get
			Set(ByVal value As Double)
				privateOffset = value
			End Set
		End Property
		Private privateScale As Double
		Public Property Scale() As Double
			Get
				Return privateScale
			End Get
			Set(ByVal value As Double)
				privateScale = value
			End Set
		End Property

		#Region "IValueConverter Members"
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim val As Double
			If TypeOf value Is Boolean Then
				val = If((CBool(value)), 1.0f, 0.0f)
			Else
				val = CDbl(value)
			End If
			Return Offset + Scale * val
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
		#End Region

		Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
			Return Me
		End Function
	End Class
End Namespace
