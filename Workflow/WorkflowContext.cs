using System.Reflection;

namespace WorkflowEngine.Workflow
{
    public abstract class WorkflowContext
    {
        public T GetValueForField<T>(string fieldName)
        {
            var typeInfo = this.GetType();
            var fieldInfo = typeInfo.GetField(fieldName);
            
            if (fieldInfo != null)
            {
                return (T)fieldInfo.GetValue(this);
            }

            return default(T);
        }

        public void SetValueForField<T>(string fieldName, T value)
        {
            var typeInfo = this.GetType();
            var fieldInfo = typeInfo.GetField(fieldName);
            
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(this, value);
            }
        }

        public T GetValueForProperty<T>(string propertyName)
        {
            var typeInfo = this.GetType();
            var propertyInfo = typeInfo.GetProperty(propertyName);

            if (propertyInfo != null)
            {
                return (T)propertyInfo.GetValue(this);
            }

            return default(T);
        }

        public void SetValueForProperty<T>(string propertyName, T value)
        {
            var typeInfo = this.GetType();
            var propertyInfo = typeInfo.GetProperty(propertyName);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(this, value);
            }
        }
    }
}