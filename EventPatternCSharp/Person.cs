namespace EventPatternCSharp;

using System.Runtime.CompilerServices;

public class Person
{
    private string m_Name;

    public string m_LastName { get; set; }

    public event PersonPropertyChangedEventHandler PropertyChanged;

    public Person()
    {
        Name = string.Empty;
        LastName = string.Empty;
    }

    public Person(string Name, string LastName)
    {
        this.Name = Name;
        this.LastName = LastName;
    }

    public string Name 
    {
        get => m_Name;

        set 
        {
            if (String.IsNullOrEmpty(value))
            {
                OnPropertyChanged(EventCodes.ChangeNameFailed);
            }
            else if (m_Name != value)
            {
                m_Name = value;
                OnPropertyChanged(EventCodes.ChangeNameSuccessful);
            }
            else
            {
                OnPropertyChanged(EventCodes.ChangeLastNameCanceled);
            }
        }
    }

    public string LastName
    {
        get => m_LastName;

        set
        {
            if (String.IsNullOrEmpty(value))
            {
                OnPropertyChanged(EventCodes.ChangeLastNameFailed);
            }
            else if (m_LastName != value)
            {
                m_LastName = value;
                OnPropertyChanged(EventCodes.ChangeLastNameSuccessful);
            }
            else
            {
                OnPropertyChanged(EventCodes.ChangeLastNameCanceled);
            }
        }
    }

    protected virtual void OnPropertyChanged(EventCodes Code, [CallerMemberName] string PropertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PersonPropertyChangedEventArgs(Code, PropertyName));
    }
}

public record PersonPropertyChangedEventArgs(EventCodes EventCode, string PropertyName);

public delegate void PersonPropertyChangedEventHandler(object Sender, PersonPropertyChangedEventArgs EventInfo);

