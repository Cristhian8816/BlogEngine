// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Utils
{
    public class DataTypeValidator
    {
        public int intId(int Id)
        {
            return (Id > 0) ? 200 : 400;
        }
    }
}
