namespace WebApp
{
    public enum StatusCode
    {
        Ok = 200,
        NotFound = 404,
        Frozen = 403,
        Error = 500
    }
    // 当我们把枚举内容直接写到命名空间下面,那么代表 在这个命名空间下的内容可以直接使用,不需要进行实例化
    
}