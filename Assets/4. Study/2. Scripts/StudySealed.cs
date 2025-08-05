using UnityEngine;

public class ParentClass : MonoBehaviour
{
    // seal :: 클래스를 상속받는걸 막음 virtual / abstract 와는 절대 쓰일일이 없고, override 앞에서 보통 쓰임
    public virtual void Method()
    {
        Debug.Log("Method");
    }
}

public class StudySealed : ParentClass
{
    public sealed override void Method()
    {
        base.Method();
    }
}

public class ChildClass : ParentClass
{
    public override void Method()
    {
        // 상속의 상속을 하는 경우 seal 로 막아줌
    }
}
