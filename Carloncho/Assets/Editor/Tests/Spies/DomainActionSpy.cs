public class DomainActionSpy
{
    public bool WasCalled { get; set; }
    public object CalledElement;
    object[] calledParameters;
    public int CalledTimes;

    public void BasicCallback()
    {
        WasCalled = true;
        CalledTimes++;
    }

    public void GenericCallback<T>(T element)
    {
        WasCalled = true;
        CalledElement = element;
    }

    public void GenericCallback<T0, T1>(T0 first, T1 second)
    {
        WasCalled = true;
        calledParameters = new object[] { first, second };
    }

    public T GetParameter<T>(int index) => (T)calledParameters[index];
}