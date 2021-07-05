namespace JSTester.Extensions
{
   static class ArrayExtension
    {
     internal static T[] GetArrayWithElementAtStart<T>(this T[]array, T value )
        {
            
            T[] result = new T[array.Length + 1];
            result[0] = value;
            for (int i = 0; i < array.Length; i++)
                result[i + 1] = array[i];

            return result;
        }
    }
}
