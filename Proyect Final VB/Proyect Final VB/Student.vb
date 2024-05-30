Public Class Student
    ' Read-only property: RegistrationNumber (once assigned, should not change)
    Private _registrationNumber As String
    Public ReadOnly Property RegistrationNumber As String
        Get
            Return _registrationNumber
        End Get
    End Property

    ' Read-write property: Name (can be read and modified)
    Private _name As String
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    ' Read-write property: LastName (can be read and modified)
    Private _lastName As String
    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    ' Read-write property: Phone (can be read and modified)
    Private _phone As String
    Public Property Phone As String
        Get
            Return _phone
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property

    ' Read-only property: Major (once assigned, should not change)
    Private _major As String
    Public ReadOnly Property Major As String
        Get
            Return _major
        End Get
    End Property

    ' Property: Email (can be set but not read, for example)
    Private _email As String
    Public Property Email As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    ' Read-only property: EmailPassword (once assigned, should not change)
    Private _emailPassword As String
    Public ReadOnly Property EmailPassword As String
        Get
            Return _emailPassword
        End Get
    End Property

    ' Constructor to initialize the properties
    Public Sub New(ByVal registrationNumber As String, ByVal name As String, ByVal lastName As String, ByVal phone As String, ByVal major As String, ByVal email As String)
        _registrationNumber = registrationNumber
        _name = name
        _lastName = lastName
        _phone = phone
        _major = major
        _email = email

        ' Generate email password (you can implement your own logic here)
        _emailPassword = GenerateEmailPassword()
    End Sub

    ' Parameterless constructor with property initialization
    Public Sub New()
        ' Logic for initializing other properties...

        ' Generate email password (you can implement your own logic here)
        _emailPassword = GenerateEmailPassword()
    End Sub

    Private Function GenerateEmailPassword() As String
        ' Implement your logic to generate a password here
        ' For simplicity, we use a fixed password in this example
        Return "AlumnoTec2024"
    End Function
End Class