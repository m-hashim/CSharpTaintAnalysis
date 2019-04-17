using System;
using System.Collections;
public class Tainted<T>
{
    private bool _tainted;
    private T _target;

    public delegate bool IsCleanUntaintTreatmentMethod(T taintedObject);

    public Tainted(T target)
    {
        _tainted = true;
        _target = target;
        
    }

    public bool IsTainted
    {
        get { return _tainted; }
    }

    public bool IsClean
    {
        get { return !this.IsTainted; }
    }

    public T Target
    {
        get
        {
            if(this.IsTainted)
            {
                throw new TaintException();
            }
            
            return _target;
        }
    }

    public T GetTarget
    {
        get
        {
            return _target;
        }
    }
    public void Taint()
    {
        _tainted = true;
    }

    public void Untaint(IsCleanUntaintTreatmentMethod treatmentMethod)
    {
        _tainted = !treatmentMethod(_target);
    }
}

public class TaintException : Exception {
   public TaintException(): base("Taint Exception !!!"){

   } 
   
}