namespace Utilities.TypeField
{
    public enum TypeFieldType
    {
        TypeString=1,
        TypeInt=2,
        TypeDecimal=3
    }

    /// <summary>
    /// GetTypeField
    /// </summary>
    public static class GetTypeField
    {
        /// <summary>
        /// Get type field
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Type field type</returns>
        public static TypeFieldType GetTypeById(int id)
        {
            return id switch
            {
                1 => TypeFieldType.TypeString,
                2 => TypeFieldType.TypeInt,
                3 => TypeFieldType.TypeDecimal,
                _ => TypeFieldType.TypeString,
            };
        }
    }
}